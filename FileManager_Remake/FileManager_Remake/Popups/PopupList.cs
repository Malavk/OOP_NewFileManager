using System;
using System.IO;

namespace OOP_FileManager
{
    class PopupList : AbstractPopup
    {
        public ListView<FileSystemInfo> ListView { get; set; }

        public PopupList(string header = "List") : base(header) { }

        public override void Render()
        {
            base.Render();

            ListView.SetOffsetY(OffsetY);

            ListView.Render();

            RestoreBackgroundColors();
        }

    }
}