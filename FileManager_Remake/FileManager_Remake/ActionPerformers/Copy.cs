using System;

namespace OOP_FileManager.ActionPerformers
{
    class Copy : AbstractActionPerformerBehavior
    {
        public override void Do(ActionPerformerArgs actionPerformerArgs)
        {
            PanelSet panelSet = (PanelSet)actionPerformerArgs.Sender;

            panelSet.CurrentItemToOperateOn = panelSet.FocusedListView.SelectedItem;
            panelSet.CurrentAction = Actions.Copy;
        }
    }
}