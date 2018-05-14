using System;
using System.Collections;
using System.Collections.Generic;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Common.FIlterStategy
{

    // ToDo: Описать логику фильтрации
    public class SortByOrientationsFilterStrategy : IFilterStrategy
    {
        public IEnumerable<IChapter> Proccess(IEnumerable<IChapter> chapters)
        {
            var result = new Queue<IChapter>(chapters);

            // ... logic here

            throw new NotImplementedException();
        }
    }
}