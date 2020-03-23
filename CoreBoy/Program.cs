using System;
using System.IO;
using SDL2;

namespace CoreBoy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            var rom = File.ReadAllBytes(@"D:\Tetris (World) (Rev A).gb");

            var cpu = new CPU(rom);

            cpu.Start();

            //using (var screen = new Screen(cpu.ScreenTick))
            //{
            //    screen.Start();
            //    System.Threading.Thread.Sleep(5000);
            //}
        }
    }
}
