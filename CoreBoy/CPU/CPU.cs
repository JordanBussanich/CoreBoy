using System;
using System.Collections.Generic;

namespace CoreBoy
{
    public partial class CPU
    {
        public CPURegisters Registers { get; } = new CPURegisters();
        public Memory Memory { get; } = new Memory();
        public byte[] ROM { get; }
        public int CycleCount { get; private set; } = 0;
        public GPU Gpu { get; }
        
        private static class DIHelper
        {
            public static bool DisableInterruptsAfterNextInstruction { get; set; } = false;
            public static bool NextInstruction { get; set; } = false;
        }

        private static class EIHelper
        {
            public static bool EnableInterruptsAfterNextInstruction { get; set; } = false;
            public static bool NextInstruction { get; set; } = false;
        }

        private Dictionary<byte, Operation> Operations = new Dictionary<byte, Operation>();

        public CPU(byte[] rom)
        {
            ROM = rom;

            Console.WriteLine("Initialising CPU...\n");

            Console.WriteLine("Set PC to 0x100");
            Registers.SetRegisterValue(Register16BitNames.PC, 0x100);

            Console.WriteLine("Set SP to 0xFFFE");
            Registers.SetRegisterValue(Register16BitNames.SP, 0xFFFE);

            Console.WriteLine("Copying first 0x4000 bytes into ROMBank0");
            Array.Copy(ROM, 0x0000, Memory.ROMBank0, 0x0000, 0x4000);

            Console.WriteLine("Copying the next 0x4000 bytes into SwitchableROMBank");
            Array.Copy(ROM, 0x4000, Memory.SwitchableROMBank, 0x0000, 0x4000);

            Console.WriteLine("Initialising Operations...");
            InitialiseOperations();

            Console.WriteLine("Initialising GPU...");
            Gpu = new GPU(this);
            
            Console.WriteLine("CPU Initialised!");
        }

        public void Start()
        {
            while(true)
            {
                if (DIHelper.DisableInterruptsAfterNextInstruction)
                {
                    DIHelper.NextInstruction = true;
                    DIHelper.DisableInterruptsAfterNextInstruction = false;
                }

                if (EIHelper.EnableInterruptsAfterNextInstruction)
                {
                    EIHelper.NextInstruction = true;
                    EIHelper.EnableInterruptsAfterNextInstruction = false;
                }

                ushort currentPC = Registers.GetRegisterValue(Register16BitNames.PC);
                byte opCode = Memory[currentPC];

                int cyclesToAdd = 0;

                try
                {
                    var operation = Operations[opCode];

                    Console.Write($"{currentPC.ToString("X4")} - 0x{opCode.ToString("X2")} - ");

                    switch (operation)
                    {
                        case NormalOperation normalOperation:
                            normalOperation.DoIt();
                            cyclesToAdd = normalOperation.Cycles;
                            break;
                        case JumpOperation jumpOperation:
                            if (jumpOperation.DoIt())
                            {
                                cyclesToAdd = jumpOperation.Cycles;
                            }
                            else
                            {
                                cyclesToAdd = jumpOperation.CyclesIfNoJump;
                            }
                            break;
                    }

                    if (operation.IncrementPC != null)
                    {
                        ushort newPC = (ushort)(currentPC +  operation.IncrementPC);
                        Registers.SetRegisterValue(Register16BitNames.PC, newPC);
                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"No implementation for opcode: 0x{opCode.ToString("X2")}");
                    Console.WriteLine($"PC: 0x{Registers.GetRegisterValue(Register16BitNames.PC).ToString("X4")}");
                    Console.WriteLine($"SP: 0x{Registers.GetRegisterValue(Register16BitNames.SP).ToString("X4")}");
                    Console.WriteLine($"AF: 0x{Registers.GetRegisterValue(Register16BitNames.AF).ToString("X4")}");
                    Console.WriteLine($"BC: 0x{Registers.GetRegisterValue(Register16BitNames.BC).ToString("X4")}");
                    Console.WriteLine($"DE: 0x{Registers.GetRegisterValue(Register16BitNames.DE).ToString("X4")}");
                    Console.WriteLine($"HL: 0x{Registers.GetRegisterValue(Register16BitNames.HL).ToString("X4")}");
                    Environment.Exit(1);
                }

                CycleCount += cyclesToAdd;

                Gpu.Step(cyclesToAdd);

                if (DIHelper.NextInstruction)
                {
                    Memory.InterruptEnable = 0x0;
                    DIHelper.NextInstruction = false;
                }

                if (EIHelper.NextInstruction)
                {
                    Memory.InterruptEnable = 0x1;
                    EIHelper.NextInstruction = false;
                }

                //System.Threading.Thread.Sleep(10);
            }
        }
    }
}