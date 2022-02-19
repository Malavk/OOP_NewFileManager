using System;
using System.IO;

namespace OOP_FileManager.ActionPerformers
{
    class Rename : AbstractActionPerformerBehavior
    {
        public override void Do(ActionPerformerArgs actionPerformerArgs)
        {
            PanelSet panelSet = (PanelSet)actionPerformerArgs.Sender;

            FileSystemInfo senderInfo = panelSet.FocusedListView.SelectedItem.Item;
            var source = senderInfo.FullName;

            PopupInput popupInput = new PopupInput(panelSet, "Enter new name:");
            popupInput.Render();
            string newName = popupInput.UserInputResult;

            var destination = Path.GetDirectoryName(source) + "\\" + newName;

            if (senderInfo is FileInfo)
            {
                File.Move(source, destination);
            }

            else if (senderInfo is DirectoryInfo)
            {
                Directory.Move(source, destination);
            }

            panelSet.RefreshScreen();
        }
    }
}