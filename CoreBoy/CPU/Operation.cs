using System;

namespace CoreBoy
{
    public class Operation
    {
        public Action Op { get; }
        public int Cycles { get; }
        public string Name { get; }
        public ushort? IncrementPC { get; }

        public Operation(Action op, string name, int cycles, ushort? incrementPC)
        {
            if (op == null)
            {
                throw new ArgumentNullException("op cannot be null.");
            }

            if (cycles < 1)
            {
                throw new ArgumentOutOfRangeException("cycles must be at least 1.");
            }

            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name cannot be null or white space.");
            }
            
            Op = op;
            Cycles = cycles;
            Name = name;
            IncrementPC = incrementPC;
        }
    }
}