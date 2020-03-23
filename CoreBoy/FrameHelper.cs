using System;
using SDL2;

namespace CoreBoy
{
    public class FrameHelper
    {
        private uint NextTime { get; set; } = 0;
        public uint FrameRate { get; }

        public FrameHelper(uint frameRate = 60)
        {
            if (frameRate != 60)
            {
                throw new ArgumentException("frameRate must be 60.");
            }

            FrameRate = frameRate;
        }

        public void NextFrame()
        {
            SDL.SDL_Delay(TimeLeft());
            NextTime += FrameRate;
        }

        private uint TimeLeft()
        {
            uint now = SDL.SDL_GetTicks();

            return NextTime <= now ? 0 : NextTime - now;
        }
    }
}