﻿using OOP_FileManager.ActionPerformers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_FileManager
{
    abstract class AbstractListView<T>
    {
        protected ConsoleColor ForegroundColor, BackgroundColorFocused, BackgroundColorUnfocused;
        protected int offsetX, offsetY;
        protected readonly int height;
        protected bool isRendered;
        protected int scroll;
        protected int selectedIndex;
        protected int previouslySelectedIndex;
        public List<int> ColumnWidths { get; set; }
        public List<T> Items { get; set; }
        public IActionPerformerBehavior ActionPerformer { get; private set; } = new NoAction();
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                previouslySelectedIndex = selectedIndex;
                selectedIndex = value;
            }
        }
        public T SelectedItem => Items[SelectedIndex];
        public bool Focused { get; set; }

        public AbstractListView(int offsetX, int offsetY, int height, int offsetXMultiplier,
            ConsoleColor newForegroundColor, ConsoleColor newBackgroundColorFocused, ConsoleColor newBackgroundColorUnfocused)
        {
            ColumnWidths = new List<int> { 32, 10, 10 };

            this.offsetX = offsetX + offsetXMultiplier * ColumnWidths.Sum() +
                (offsetXMultiplier > 0 ? 2 : 0);
            this.offsetY = offsetY;

            this.height = height;

            this.ForegroundColor = newForegroundColor;
            this.BackgroundColorFocused = newBackgroundColorFocused;
            this.BackgroundColorUnfocused = newBackgroundColorUnfocused;
        }

        abstract public void Clean();

        virtual public void Render()
        {
            if (selectedIndex > height + scroll - 1)
            {
                scroll++;
                isRendered = false;
            }
            else if (selectedIndex < scroll)
            {
                scroll--;
                isRendered = false;
            }
        }

        public void Update(ConsoleKeyInfo key)
        {
            ActionPerformerArgs args = new ActionPerformerArgs(key, this);
            ActionPerformer = ActionPerformer.GetActionPerformer(args);
            ActionPerformer.Do(args);
        }

        public void SetOffsetY(int offsetY)
        {
            this.offsetY = offsetY;
        }
    }
}