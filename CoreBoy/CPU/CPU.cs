using System;
using System.Collections.Generic;

namespace CoreBoy
{
    public partial class CPU
    {
        /* private class Operation
        {
            public Action Op { get; }
            public string Name { get; }
            public int Cycles { get; }

            public Operation(Action op, string name, int cycles)
            {
                if (op == null)
                {
                    throw new ArgumentNullException("op cannot be null.");
                }
                
                if (String.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException("name must not be null or empty.");
                }

                if (cycles < 1)
                {
                    throw new ArgumentOutOfRangeException("cycles must be at least 1.");
                }

                Op = op;
                Cycles = cycles;
            }
        } */

        public CPURegisters Registers { get; } = new CPURegisters();
        public Memory Memory { get; } = new Memory();
        public byte[] ROM { get; }

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
            
            Console.WriteLine("CPU Initialised!");
        }

        public void Start()
        {
            while(true)
            {
                ushort currentPC = Registers.GetRegisterValue(Register16BitNames.PC);
                byte opCode = Memory[currentPC];

                try
                {
                    var operation = Operations[opCode];

                    Console.Write($"{currentPC.ToString("X4")} - 0x{opCode.ToString("X2")} - ");

                    operation.Op.Invoke();

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
                    Environment.Exit(1);
                }

                //System.Threading.Thread.Sleep(50);
            }
        }

        public void ScreenTick()
        {

        }
    }
}