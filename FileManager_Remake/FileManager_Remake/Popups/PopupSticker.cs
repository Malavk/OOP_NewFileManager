﻿using System;

namespace OOP_FileManager
{
    class PopupSticker : AbstractPopup
    {
        private string message;

        public PopupSticker(int height, int width, int offsetX, int offsetY, string message, string header = "Info")
            : base(height, width, offsetX, offsetY, header)
        {
            this.message = message;
        }

        public override void Render()
        {
            base.Render();

            if (!String.IsNullOrWhiteSpace(message))
            {
                var lines = message.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                for (int i = 0; i < lines.Length; i++)
                {
                    Console.CursorTop = OffsetY + i;
                    Console.CursorLeft = OffsetX;
                    Console.WriteLine(lines[i].NormalizeStringLength(Width - 1));
                }
            }

            RestoreBackgroundColors();
        }
    }
}