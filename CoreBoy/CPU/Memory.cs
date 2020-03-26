using System;

namespace CoreBoy
{
    public class Memory
    {
        public byte[] ROMBank0 { get; private set; } = new byte[0x4000];          // 0x0000 - 0x3FFF
        public byte[] SwitchableROMBank { get; private set; } = new byte[0x4000]; // 0x4000 - 0x7FFF
        public byte[] VideoRAM { get; private set; } = new byte[0x2000];          // 0x8000 - 0x9FFF
        public byte[] SwitchableRAMBank { get; private set; } = new byte[0x2000]; // 0xA000 - 0xBFFF
        public byte[] InternalRAM { get; private set; } = new byte[0x2000];       // 0xC000 - 0xDFFF
        public byte[] SpriteAttributes { get; private set; } = new byte[0x00A0];  // 0xFE00 - 0xFE9F
        public byte[] SpecialRegisters { get; private set; } = new byte[0x004C];   // 0xFF00 - 0xFF4B
        public byte[] InternalRAM2 { get; private set; } = new byte[0x007F];      // 0xFF80 - 0xFFFE

        public byte InterruptEnable { get; set; } = 0x00;

        public byte this[ushort i]
        {
            get
            {
                return GetByte(i);
            }
            set
            {
                SetByte(i, value);
            }
        }

        public byte this[int i]
        {
            get
            {
                if (i < UInt16.MinValue || i > UInt16.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("i out of range");
                }

                return GetByte((ushort)i);
            }
            set
            {
                if (i < UInt16.MinValue || i > UInt16.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("i out of range");
                }

                SetByte((ushort)i, value);
            }
        }

        private byte GetByte(ushort address)
        {
            if (address < 0x4000)
            {
                return ROMBank0[address];
            }
            else if (address >= 0x4000 && address < 0x8000)
            {
                return SwitchableROMBank[address - 0x4000];
            }
            else if (address >= 0x8000 && address < 0xA000)
            {
                return VideoRAM[address - 0x8000];
            }
            else if (address >= 0xA000 && address < 0xC000)
            {
                return SwitchableRAMBank[address - 0xA000];
            }
            else if (address >= 0xC000 && address < 0xE000)
            {
                return InternalRAM[address - 0xC000];
            }
            else if (address >= 0xE000 && address < 0xFE00)
            {
                return InternalRAM[address - 0xE000];
            }
            else if (address >= 0xFE00 && address < 0xFEA0)
            {
                return SpriteAttributes[address - 0xFE00];
            }
            else if (address >= 0xFEA0 && address < 0xFF00)
            {
                throw new NotImplementedException("Empty - Not usable for I/O");
            }
            else if (address >= 0xFF00 && address < 0xFF4C)
            {
                return SpecialRegisters[address - 0xFF00];
            }
            else if (address >= 0xFF4C && address < 0xFF80)
            {
                throw new NotImplementedException("Empty - Not usable for I/O");
            }
            else if (address >= 0xFF80 && address < 0xFFFF)
            {
                return InternalRAM2[address - 0xFF80];
            }
            else if (address == 0xFFFF)
            {
                return InterruptEnable;
            }
            else
            {
                throw new Exception("This should never happen.");
            }
        }

        private void SetByte(ushort address, byte value)
        {
            if (address < 0x4000)
            {
                ROMBank0[address] = value;
            }
            else if (address >= 0x4000 && address < 0x8000)
            {
                SwitchableROMBank[address - 0x4000] = value;
            }
            else if (address >= 0x8000 && address < 0xA000)
            {
                VideoRAM[address - 0x8000] = value;
            }
            else if (address >= 0xA000 && address < 0xC000)
            {
                SwitchableRAMBank[address - 0xA000] = value;
            }
            else if (address >= 0xC000 && address < 0xE000)
            {
                InternalRAM[address - 0xC000] = value;
            }
            else if (address >= 0xE000 && address < 0xFE00)
            {
                InternalRAM[address - 0xE000] = value;
            }
            else if (address >= 0xFE00 && address < 0xFEA0)
            {
                SpriteAttributes[address - 0xFE00] = value;
            }
            else if (address >= 0xFEA0 && address < 0xFF00)
            {
                // Ignore it, just continue
                Console.WriteLine($"WARNING - Attempted to write to 0x{address.ToString("X4")}");
            }
            else if (address >= 0xFF00 && address < 0xFF4C)
            {
                SpecialRegisters[address - 0xFF00] = value;
            }
            else if (address >= 0xFF4C && address < 0xFF80)
            {
                // Ignore it, just continue
                Console.WriteLine($"WARNING - Attempted to write to 0x{address.ToString("X4")}");
            }
            else if (address >= 0xFF80 && address < 0xFFFF)
            {
                InternalRAM2[address - 0xFF80] = value;
            }
            else if (address == 0xFFFF)
            {
                InterruptEnable = value;
            }
            else
            {
                throw new Exception("This should never happen.");
            }
        }
    }
}