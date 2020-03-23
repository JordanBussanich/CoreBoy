using System;
using System.Collections.Generic;

namespace CoreBoy
{
    public partial class CPU
    {
        private class Operation
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
        }

        public CPURegisters Registers { get; } = new CPURegisters();
        public Memory Memory { get; } = new Memory();
        public byte[] ROM { get; }

        private Dictionary<byte, Operation> Operations = new Dictionary<byte, Operation>();

        public CPU(byte[] rom)
        {
            ROM = rom;

            Console.WriteLine("Initialising CPU...\n");

            Console.WriteLine("Set PC to 0x100");
            Registers.PC.Value = 0x100;

            Console.WriteLine("Set SP to 0xFFFE");
            Registers.SP.Value = 0xFFFE;

            Console.WriteLine("Copying first 0x4000 bytes into ROMBank0");
            Array.Copy(ROM, 0x0000, Memory.ROMBank0, 0x0000, 0x4000);

            Console.WriteLine("Copying the next 0x4000 bytes into SwitchableROMBank");
            Array.Copy(ROM, 0x4000, Memory.SwitchableROMBank, 0x0000, 0x4000);

            Console.WriteLine("Initialising Operations...");
            InitialiseOperations();
        }

        public void Start()
        {
            while(true)
            {
                try
                {
                    Operations[Memory[Registers.PC.Value]].Op.Invoke();
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"No implementation for opcode: {Memory[Registers.PC.Value].ToString("X2")}");
                    Environment.Exit(1);
                }
            }
        }

        public void ScreenTick()
        {

        }

        private void InitialiseOperations()
        {
            var ops = new Ops(this);

            // 0x00 - NOP
            Operations.Add(0x00, ops.NOP());      

            // 0x01 - LD BC,nn
            Operations.Add(0x01, ops.LD_BC_nn());

            // 0x11 - LD DE,nn
            Operations.Add(0x11, ops.LD_DE_nn());

            // 0x21 - LD HL,nn
            Operations.Add(0x21, ops.LD_HL_nn());

            // 0x31 - LD SP,nn
            Operations.Add(0x31, ops.LD_SP_nn());

            // 0xA8 - XOR B
            Operations.Add(0xA8, ops.XOR_B());

            // 0xA9 - XOR C
            Operations.Add(0xA9, ops.XOR_C());

            // 0xAA - XOR D
            Operations.Add(0xAA, ops.XOR_D());

            // 0xAB - XOR E
            Operations.Add(0xAB, ops.XOR_E());

            // 0xAC - XOR H
            Operations.Add(0xAC, ops.XOR_H());

            // 0xAD - XOR L
            Operations.Add(0xAD, ops.XOR_L());

            // 0xAF - XOR A
            Operations.Add(0xAF, ops.XOR_A());

            // 0xC3 - JP, nn
            Operations.Add(0xC3, ops.JP_nn());
        }
    }
}