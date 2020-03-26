using System;

namespace CoreBoy
{
    public abstract class Operation
    {
        public int Cycles { get; }
        public string Name { get; }
        public ushort? IncrementPC { get; }

        public Operation(string name, int cycles, ushort? incrementPC)
        {
            if (cycles < 1)
            {
                throw new ArgumentOutOfRangeException("cycles must be at least 1.");
            }

            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name cannot be null or white space.");
            }
            
            Cycles = cycles;
            Name = name;
            IncrementPC = incrementPC;
        }
    }
}