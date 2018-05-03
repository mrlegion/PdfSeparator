﻿using System.Collections.Generic;

namespace PdfSeparator.Model.Interface
{
    public interface IPdf : IComponent
    {
        bool IsOpen { get; }
        bool IsClose { get; }
        void Open(string file);
        void Close();
        Queue<IChapter> GetChapters { get; }
        int Count { get; }
    }
}