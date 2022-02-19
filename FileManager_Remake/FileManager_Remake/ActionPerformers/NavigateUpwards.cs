using System;
using System.IO;

namespace OOP_FileManager.ActionPerformers
{
    class NavigateUpwards : AbstractActionPerformerBehavior
    {
        public override void Do(ActionPerformerArgs actionPerformerArgs)
        {
            PanelSet panelSet = (PanelSet)actionPerformerArgs.Sender;

            var parent = Directory.GetParent(panelSet.FocusedListView.Current.FullName)
                ?? new DirectoryInfo(Path.GetPathRoot(panelSet.FocusedListView.Current.FullName));

            panelSet.FocusedListView.Current = parent;

            panelSet.RefreshFocusedPanel();
        }
    }
}