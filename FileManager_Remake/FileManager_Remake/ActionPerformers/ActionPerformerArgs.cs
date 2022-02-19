using System;

namespace OOP_FileManager
{
    class ActionPerformerArgs
    {
        public ConsoleKeyInfo Key { get; private set; }
        public object Sender { get; private set; }

        public ActionPerformerArgs(ConsoleKeyInfo key, object sender)
        {
            Key = key;
            Sender = sender;
        }
    }
}