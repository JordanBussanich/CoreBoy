using System;
using SDL2;

namespace CoreBoy
{
    class Program
    {
        static void Main(string[] args)
        {
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            var window = IntPtr.Zero;                        
            window = SDL.SDL_CreateWindow(".NET Core SDL2-CS Tutorial",
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                1028,
                800,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
            );

            SDL.SDL_Delay(5000);
            SDL.SDL_DestroyWindow(window);            
            SDL.SDL_Quit();
        }
    }
}
