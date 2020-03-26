using System;

namespace CoreBoy
{
    public class JumpOperation : Operation
    {
        public int CyclesIfNoJump { get; }

        protected Func<bool> Op { get; }

        public JumpOperation(Func<bool> op, string name, int cycles, ushort? incrementPC, int cyclesIfNoJump) :
            base(name, cycles, incrementPC)
        {
            if (cyclesIfNoJump < 1)
            {
                throw new ArgumentOutOfRangeException("cyclesIfNoJump must be at least 1.");
            }

            if (op == null)
            {
                throw new ArgumentNullException("op cannot be null.");
            }

            Op = op;
            CyclesIfNoJump = cyclesIfNoJump;
        }

        public bool DoIt() => Op.Invoke();
    }
}