using System;

namespace OOP_FileManager.ActionPerformers
{
    interface IActionPerformerBehavior
    {
        void Do(ActionPerformerArgs actionPerformerArgs);
        IActionPerformerBehavior GetActionPerformer(ActionPerformerArgs actionPerformerArgs);
    }
}