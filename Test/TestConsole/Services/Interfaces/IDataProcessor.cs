﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Data;

namespace TestConsole.Services.Interfaces
{ 
    public interface IDataProcessor
    {
        void Process(DataValue Value);
    }
}