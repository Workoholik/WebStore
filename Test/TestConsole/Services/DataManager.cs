using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Data;
using TestConsole.Services.Interfaces;

namespace TestConsole.Services
{
    public class DataManager : IDataManager, IDisposable
    {
        private IDataProcessor _Processor;

        public DataManager(IDataProcessor Processor)
        {
            _Processor = Processor; 
        }

        public void ProcessData(IEnumerable<DataValue> Values)
        {
            foreach (DataValue Value in Values)
            {
                _Processor.Process(Value);
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Manager Dispose");
        }
    }
}
