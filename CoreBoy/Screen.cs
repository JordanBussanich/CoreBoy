using System;
using System.Threading;
using SDL2;

namespace CoreBoy
{
    public class Screen : IDisposable
    {
        public int MinimumX { get; } = 160;
        public int MinimumY { get; } = 144;
        public uint FrameRate { get; } = 60;
        public int ScaleFactor { get; }
        private IntPtr Window { get; }
        private IntPtr Renderer { get; }
        private FrameHelper FrameHelper { get; } 
        private Action FrameCallback { get; }      

        public Screen(Action frameCallback, int scaleFactor = 1)
        {
            if (scaleFactor < 1)
            {
                throw new ArgumentOutOfRangeException("scaleFactor must not be less than 1.");
            }

            ScaleFactor = scaleFactor;
            FrameHelper = new FrameHelper(FrameRate);
            FrameCallback = frameCallback;

            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            Window = IntPtr.Zero;                        
            Window = SDL.SDL_CreateWindow("CoreBoy",
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                MinimumX * ScaleFactor,
                MinimumY * ScaleFactor,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
            );

            Renderer = SDL.SDL_CreateRenderer(Window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
        }

        public void Start()
        {
            var screenThread = new Thread(() => 
            {
                bool quit = false;
                var eventHandler = new SDL.SDL_Event();

                SDL.SDL_SetRenderDrawColor(Renderer, 0, 0, 0, 1);

                SDL.SDL_RenderClear(Renderer);

                SDL.SDL_RenderPresent(Renderer);

                while (!quit)
                {
                    FrameHelper.NextFrame();
                    FrameCallback.Invoke();
                }

            });

            screenThread.Start();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    SDL.SDL_DestroyRenderer(Renderer);
                    SDL.SDL_DestroyWindow(Window);            
                    SDL.SDL_Quit();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Screen()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}