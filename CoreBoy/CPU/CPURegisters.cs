using System;

namespace CoreBoy
{
    public class CPURegisters
    {
        public Register8Bit A { get; } = new Register8Bit();
        public Register8Bit B { get; } = new Register8Bit();
        public Register8Bit C { get; } = new Register8Bit();
        public Register8Bit D { get; } = new Register8Bit();
        public Register8Bit E { get; } = new Register8Bit();
        public Register8Bit F { get; } = new Register8Bit();
        public Register8Bit H { get; } = new Register8Bit();
        public Register8Bit L { get; } = new Register8Bit();
        public Register16Bit SP { get; } = new Register16Bit();
        public Register16Bit PC { get; } = new Register16Bit();

        public ushort AF
        {
            get
            {
                return (ushort)((A.Value << 8) | F.Value);
            }
            set
            {
                A.Value = (byte)((value & 0b_1111_1111_0000_0000) >> 8);
                F.Value = (byte)(value & 0b_0000_0000_1111_1111);
            }
        }
        public ushort BC
        {
            get
            {
                return (ushort)((B.Value << 8) | C.Value);
            }
            set
            {
                B.Value = (byte)((value & 0b_1111_1111_0000_0000) >> 8);
                C.Value = (byte)(value & 0b_0000_0000_1111_1111);
            }
        }
        public ushort DE
        {
            get
            {
                return (ushort)((D.Value << 8) | E.Value);
            }
            set
            {
                D.Value = (byte)((value & 0b_1111_1111_0000_0000) >> 8);
                E.Value = (byte)(value & 0b_0000_0000_1111_1111);
            }
        }
        public ushort HL
        {
            get
            {
                return (ushort)((H.Value << 8) | L.Value);
            }
            set
            {
                H.Value = (byte)((value & 0b_1111_1111_0000_0000) >> 8);
                L.Value = (byte)(value & 0b_0000_0000_1111_1111);
            }
        }
        public bool ZZeroFlag
        {
            get 
            {
                return (F.Value & (1 << 7)) != 0;
            }
            set
            {
                if (value == true)
                {
                    F.Value = (byte)(F.Value | 0b_1000_0000);
                }
                else
                {
                    F.Value = (byte)(F.Value & 0b_0111_1111);
                }
            }
        }
        public bool NSubtractFlag
        {
            get 
            {
                return (F.Value & (1 << 6)) != 0;
            }
            set
            {
                if (value == true)
                {
                    F.Value = (byte)(F.Value | 0b_0100_0000);
                }
                else
                {
                    F.Value = (byte)(F.Value & 0b_1011_1111);
                }
            }
        }
        public bool HHalfCarryFlag
        {
            get 
            {
                return (F.Value & (1 << 5)) != 0;
            }
            set
            {
                if (value == true)
                {
                    F.Value = (byte)(F.Value | 0b_0010_0000);
                }
                else
                {
                    F.Value = (byte)(F.Value & 0b_1101_1111);
                }
            }
        }
        public bool CCarryFlag
        {
            get 
            {
                return (F.Value & (1 << 4)) != 0;
            }
            set
            {
                if (value == true)
                {
                    F.Value = (byte)(F.Value | 0b_0001_0000);
                }
                else
                {
                    F.Value = (byte)(F.Value & 0b_1110_1111);
                }
            }
        }
    }
}