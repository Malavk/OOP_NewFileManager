﻿using OOP_FileManager.ActionPerformers;
using System;

namespace OOP_FileManager
{
    abstract class AbstractPopup
    {
        protected readonly string header;
        public ConsoleColor SavedForegroundColor { get; protected set; }
        public ConsoleColor SavedBackgroundColor { get; protected set; }
        public ConsoleColor ForegroundColor { get; protected set; }
        public ConsoleColor BackgroundColor { get; protected set; }
        public int OffsetX { get; protected set; }
        public int OffsetY { get; protected set; }
        public int Height { get; protected set; }
        public int Width { get; protected set; }
        public IActionPerformerBehavior ActionPerformer { get; protected set; }

        public AbstractPopup(int height, int width, int offsetX, int offsetY, string header,
            ConsoleColor ForegroundColor = ConsoleColor.DarkMagenta,
            ConsoleColor BackgroundColor = ConsoleColor.DarkCyan)
        {
            this.Height = height;
            this.Width = width;
            this.header = header;
            this.ForegroundColor = ForegroundColor;
            this.BackgroundColor = BackgroundColor;

            this.OffsetX = offsetX;
            this.OffsetY = offsetY;
        }

        public AbstractPopup(string header, int height = 13, int width = 50,
            ConsoleColor newForegroundColor = ConsoleColor.DarkMagenta,
            ConsoleColor newBackgroundColor = ConsoleColor.DarkCyan)
        {
            this.header = header;
            this.ForegroundColor = newForegroundColor;
            this.BackgroundColor = newBackgroundColor;

            Width = width;
            Height = height;

            OffsetX = Console.WindowWidth / 2 - Width / 2;
            OffsetY = Console.WindowHeight / 2 - Height / 2;
        }

        virtual public void Render()
        {
            string background = "".PadRight(Width, ' ');

            SaveBackgroundColors();

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;

            for (int i = 0; i < Height; i++)
            {
                Console.CursorTop = OffsetY + i;
                Console.CursorLeft = OffsetX;
                Console.WriteLine(background);
            }

            OffsetX++;
            Console.CursorTop = OffsetY;
            Console.CursorLeft = OffsetX;
            Console.WriteLine(header.NormalizeStringLength(Width - 1));

            OffsetY += 2;
        }

        protected void SaveBackgroundColors()
        {
            SavedForegroundColor = Console.ForegroundColor;
            SavedBackgroundColor = Console.BackgroundColor;
        }

        protected void RestoreBackgroundColors()
        {
            Console.ForegroundColor = SavedForegroundColor;
            Console.BackgroundColor = SavedBackgroundColor;
        }
    }
}