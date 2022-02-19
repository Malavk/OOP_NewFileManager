using System;
using System.IO;

namespace OOP_FileManager.ActionPerformers
{
    class MoveCursorUp : AbstractActionPerformerBehavior
    {
        public override void Do(ActionPerformerArgs actionPerformerArgs)
        {
            ListView<FileSystemInfo> listView = (ListView<FileSystemInfo>)actionPerformerArgs.Sender;

            if (listView.SelectedIndex != 0)
                listView.SelectedIndex--;
        }
    }
}