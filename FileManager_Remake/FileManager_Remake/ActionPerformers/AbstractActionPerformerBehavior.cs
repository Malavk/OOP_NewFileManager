﻿using System;

namespace OOP_FileManager.ActionPerformers
{
    abstract class AbstractActionPerformerBehavior : IActionPerformerBehavior
    {
        abstract public void Do(ActionPerformerArgs actionPerformerArgs);

        public IActionPerformerBehavior GetActionPerformer(ActionPerformerArgs actionPerformerArgs)
        {
            ConsoleKeyInfo key = actionPerformerArgs.Key;

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    return new MoveCursorUp();
                case ConsoleKey.DownArrow:
                    return new MoveCursorDown();
                case ConsoleKey.Enter:
                    return new OpenFileFolder();
                case ConsoleKey.RightArrow:
                    return new ChoosePreviousPanel();
                case ConsoleKey.LeftArrow:
                    return new ChooseNextPanel();
                case ConsoleKey.F1:
                    return new Copy();
                case ConsoleKey.F2:
                    return new Rename();
                case ConsoleKey.F3:
                    return new Cut();
                case ConsoleKey.F4:
                    return new Paste();
                case ConsoleKey.F5:
                    return new NavigateToRoot();
                case ConsoleKey.F6:
                    return new ShowProperties();
                case ConsoleKey.F7:
                    return new CreateNewFolder();
                case ConsoleKey.F8:
                    return new SelectDrive();
                case ConsoleKey.F9:
                    return new Search();
                case ConsoleKey.Backspace:
                    return new NavigateUpwards();
                default:
                    return new NoAction();
            }
        }
    }
}