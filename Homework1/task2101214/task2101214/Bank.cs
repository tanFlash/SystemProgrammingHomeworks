using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task2101214
{
    class Bank
    {
        public int _money;
        public string _name;
        public int _percent;

        public int Money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
                ParameterizedThreadStart threadstart = new ParameterizedThreadStart(WriteFile);
                Thread thread = new Thread(threadstart);
                thread.Start((object)value);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                ParameterizedThreadStart threadstart = new ParameterizedThreadStart(WriteFile);
                Thread thread = new Thread(threadstart);
                thread.Start((object)value);
            }
        }
        public int Percent {
            get
            {
                return _percent;
            }
            set
            {
                _percent = value;
                ParameterizedThreadStart threadstart = new ParameterizedThreadStart(WriteFile);
                Thread thread = new Thread(threadstart);
                thread.Start((object)value);
            }
        }

        public void WriteFile(object data)
        {
            DirectoryInfo di = new DirectoryInfo("Data");
            di.Create();
            StreamWriter sw = File.AppendText("Data\\property.txt");
            sw.WriteLine("Your property is " + data.ToString());
            sw.Close();
        }


    }
}
