using System;

namespace CoreBoy
{
    public class NormalOperation : Operation
    {
        protected Action Op { get; }

        public NormalOperation(Action op, string name, int cycles, ushort? incrementPC) :
            base(name, cycles, incrementPC)
        {
            if (op == null)
            {
                throw new ArgumentNullException("op cannot be null.");
            }

            Op = op;
        }

        public void DoIt() => Op.Invoke();
    }
}