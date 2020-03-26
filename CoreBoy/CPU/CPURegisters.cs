using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreBoy
{
    public enum Register8BitNames
        {
            A,
            B,
            C,
            D,
            E,
            F,
            H,
            L,
        }

        public enum Register16BitNames
        {
            SP,
            PC,
            AF,
            BC,
            DE,
            HL
        }
    public class CPURegisters
    {
        private Dictionary<Register8BitNames, Register8Bit> registers8Bit = new Dictionary<Register8BitNames, Register8Bit>();
        private Dictionary<Register16BitNames, Register16Bit> registers16Bit = new Dictionary<Register16BitNames, Register16Bit>();

        public CPURegisters()
        {
            foreach (var register in Enum.GetValues(typeof(Register8BitNames)).Cast<Register8BitNames>())
            {
                registers8Bit.Add(register, new Register8Bit());
            }

            foreach (var register in Enum.GetValues(typeof(Register16BitNames)).Cast<Register16BitNames>())
            {
                registers16Bit.Add(register, new Register16Bit());
            }
        }

        public byte GetRegisterValue(Register8BitNames register)
        {
            return registers8Bit[register].Value;
        }

        public ushort GetRegisterValue(Register16BitNames register)
        {
            switch (register)
            {
                case (Register16BitNames.AF):
                    return (ushort)((registers8Bit[Register8BitNames.A].Value << 8) | registers8Bit[Register8BitNames.F].Value);
                case (Register16BitNames.BC):
                    return (ushort)((registers8Bit[Register8BitNames.B].Value << 8) | registers8Bit[Register8BitNames.C].Value);
                case (Register16BitNames.DE):
                    return (ushort)((registers8Bit[Register8BitNames.D].Value << 8) | registers8Bit[Register8BitNames.E].Value);
                case (Register16BitNames.HL):
                    return (ushort)((registers8Bit[Register8BitNames.H].Value << 8) | registers8Bit[Register8BitNames.L].Value);
                default:
                    return registers16Bit[register].Value;
            }
        }

        public void SetRegisterValue(Register8BitNames register, byte value)
        {
            registers8Bit[register].Value = value;
        }

        public void SetRegisterValue(Register16BitNames register, ushort value)
        {
            switch (register)
            {
                case (Register16BitNames.AF):
                    registers8Bit[Register8BitNames.A].Value = (byte)((value & 0b_1111_1111_0000_0000) >> 8);
                    registers8Bit[Register8BitNames.F].Value = (byte)(value & 0b_0000_0000_1111_1111);
                    break;
                case (Register16BitNames.BC):
                    registers8Bit[Register8BitNames.B].Value = (byte)((value & 0b_1111_1111_0000_0000) >> 8);
                    registers8Bit[Register8BitNames.C].Value = (byte)(value & 0b_0000_0000_1111_1111);
                    break;
                case (Register16BitNames.DE):
                    registers8Bit[Register8BitNames.D].Value = (byte)((value & 0b_1111_1111_0000_0000) >> 8);
                    registers8Bit[Register8BitNames.E].Value = (byte)(value & 0b_0000_0000_1111_1111);
                    break;
                case (Register16BitNames.HL):
                    registers8Bit[Register8BitNames.H].Value = (byte)((value & 0b_1111_1111_0000_0000) >> 8);
                    registers8Bit[Register8BitNames.L].Value = (byte)(value & 0b_0000_0000_1111_1111);
                    break;
                default:
                    registers16Bit[register].Value = value;
                    break;
            }
        }

        public bool ZZeroFlag
        {
            get 
            {
                return (registers8Bit[Register8BitNames.F].Value & (1 << 7)) != 0;
            }
            set
            {
                if (value == true)
                {
                    registers8Bit[Register8BitNames.F].Value = (byte)(registers8Bit[Register8BitNames.F].Value | 0b_1000_0000);
                }
                else
                {
                    registers8Bit[Register8BitNames.F].Value = (byte)(registers8Bit[Register8BitNames.F].Value & 0b_0111_1111);
                }
            }
        }
        public bool NSubtractFlag
        {
            get 
            {
                return (registers8Bit[Register8BitNames.F].Value & (1 << 6)) != 0;
            }
            set
            {
                if (value == true)
                {
                    registers8Bit[Register8BitNames.F].Value = (byte)(registers8Bit[Register8BitNames.F].Value | 0b_0100_0000);
                }
                else
                {
                    registers8Bit[Register8BitNames.F].Value = (byte)(registers8Bit[Register8BitNames.F].Value & 0b_1011_1111);
                }
            }
        }
        public bool HHalfCarryFlag
        {
            get 
            {
                return (registers8Bit[Register8BitNames.F].Value & (1 << 5)) != 0;
            }
            set
            {
                if (value == true)
                {
                    registers8Bit[Register8BitNames.F].Value = (byte)(registers8Bit[Register8BitNames.F].Value | 0b_0010_0000);
                }
                else
                {
                    registers8Bit[Register8BitNames.F].Value = (byte)(registers8Bit[Register8BitNames.F].Value & 0b_1101_1111);
                }
            }
        }
        public bool CCarryFlag
        {
            get 
            {
                return (registers8Bit[Register8BitNames.F].Value & (1 << 4)) != 0;
            }
            set
            {
                if (value == true)
                {
                    registers8Bit[Register8BitNames.F].Value = (byte)(registers8Bit[Register8BitNames.F].Value | 0b_0001_0000);
                }
                else
                {
                    registers8Bit[Register8BitNames.F].Value = (byte)(registers8Bit[Register8BitNames.F].Value & 0b_1110_1111);
                }
            }
        }
    }
}