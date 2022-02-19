using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_FileManager
{
    class ListViewItem<T> : AbstarctListViewItem<T>
    {
        public ListViewItem(T item, params string[] columns) : base(item, columns) { }

        public override void Render(List<int> columnsWidth, int elementIndex, int listViewX, int listViewY)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                Console.CursorLeft = listViewX + columnsWidth.Take(i).Sum();
                Console.CursorTop = elementIndex + listViewY;
                Console.Write(columns[i].NormalizeStringLength(columnsWidth[i]));
            }
        }
    }
}