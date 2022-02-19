﻿using System;
using System.IO;

namespace OOP_FileManager.ActionPerformers
{
    class MoveCursorDown : AbstractActionPerformerBehavior
    {
        public override void Do(ActionPerformerArgs actionPerformerArgs)
        {
            ListView<FileSystemInfo> listView = (ListView<FileSystemInfo>)actionPerformerArgs.Sender;

            if (listView.SelectedIndex < listView.Items.Count - 1)
                listView.SelectedIndex++;
        }
    }
}