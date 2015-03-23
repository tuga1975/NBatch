﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NBatch.Core.Repositories
{
    sealed class InMemoryJobRepository : IJobRepository
    {
        private readonly IList<long> _dbIndexes = new List<long> {0};
        private int _exceptionCount = 0;

        public long GetStartIndex(string stepName)
        {
            return _dbIndexes.Last();
        }

        public void CreateJobRecord(ICollection<string> stepNames)
        {
            
        }

        public void SaveIndex(string stepName, long index)
        {
            _dbIndexes.Add(index);
        }

        public int GetExceptionCount(SkipContext context)
        {
            return _exceptionCount;
        }

        public void SaveExceptionInfo(SkipContext skipContext, int currentCount)
        {
            ++_exceptionCount;
            Console.WriteLine("Skippable exception on line: {0} - {1}", skipContext.LineNumber, skipContext.Exception.Message);
        }
    }
}