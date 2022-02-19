﻿using System;

namespace OOP_FileManager
{
    class PopupInput : AbstractPopup
    {
        private PanelSet panelSet;
        private string message;
        public string UserInputResult { get; private set; }

        public PopupInput(PanelSet panelSet, string message, string header = "Input") : base(header)
        {
            this.panelSet = panelSet;
            this.message = message;
        }

        public override void Render()
        {
            base.Render();

            string newName = String.Empty;

            while (NameIsValid(newName))
            {
                Console.CursorTop = OffsetY + 1;
                Console.CursorLeft = OffsetX + 1;
                Console.WriteLine(message.NormalizeStringLength(Width - 2));

                Console.CursorTop = OffsetY + 3;
                Console.CursorLeft = OffsetX + 1;
                newName = Console.ReadLine();
            }

            UserInputResult = newName;

            RestoreBackgroundColors();

            panelSet.RefreshScreen();
        }

        private bool NameIsValid(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                return true;
            else
                return false;
        }
    }
}