using System;

namespace CoreBoy
{
    public enum GPUModes
    {
        HBlank = 0,
        VBlank = 1,
        ScanlineOAMRead = 2,
        ScanlineVRAMRead = 3
    }

    public class GPU
    {
        protected CPU Cpu { get; }

        private byte _currentLine = 0;
        public byte CurrentLine 
        { 
            get
            {
                return _currentLine;
            }
            private set
            {
                _currentLine = value;
                Cpu.Memory[0xFF44] = _currentLine;
            } 
        }

        public int ModeClock { get; private set; }
        
        public GPUModes Mode { get; private set; } = GPUModes.HBlank;
        
        public GPU(CPU cpu)
        {
            if (cpu == null)
            {
                throw new ArgumentNullException("cpu must not be null.");
            }

            Cpu = cpu;
        }

        public void Step(int previousInstructionCycles)
        {
            ModeClock += previousInstructionCycles;

            switch (Mode)
            {
                case GPUModes.HBlank:
                    if (ModeClock >= 204)
                    {
                        ModeClock = 0;
                        CurrentLine++;

                        if (CurrentLine == 143)
                        {
                            Mode = GPUModes.VBlank;

                            // WRITE TO THE SCREEN HERE
                        }
                        else
                        {
                            Mode = GPUModes.ScanlineOAMRead;
                        }
                    }
                    break;
                case GPUModes.VBlank:
                    if (ModeClock >= 456)
                    {
                        ModeClock = 0;
                        CurrentLine++;

                        if (CurrentLine > 153)
                        {
                            Mode = GPUModes.ScanlineOAMRead;
                            CurrentLine = 0;
                        }
                    }
                    break;
                case GPUModes.ScanlineOAMRead:
                    if (ModeClock >= 80)
                    {
                        ModeClock = 0;
                        Mode = GPUModes.ScanlineVRAMRead;
                    }
                    break;
                case GPUModes.ScanlineVRAMRead:
                    if (ModeClock >= 172)
                    {
                        ModeClock = 0;
                        Mode = GPUModes.HBlank;

                        // WRITE THE SCANLINE HERE
                    }
                    break;
            }
        }
    }
}