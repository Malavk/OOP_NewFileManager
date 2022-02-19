﻿using System;

namespace OOP_FileManager
{
    class PopupMessage : AbstractPopup
    {
        private PanelSet panelSet;
        private string message;

        public PopupMessage(PanelSet panelSet, string message, string header = "Info") : base(header)
        {
            this.panelSet = panelSet;
            this.message = message;
        }

        public override void Render()
        {
            base.Render();

            var lines = message.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                Console.CursorTop = OffsetY + i;
                Console.CursorLeft = OffsetX;
                Console.WriteLine(lines[i].NormalizeStringLength(Width - 1));
            }

            Console.ReadKey();

            RestoreBackgroundColors();

            if (panelSet != null)
                panelSet.RefreshScreen();
        }
    }
}