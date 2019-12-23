using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueAPI
{
    public class Input
    {
        public string Key { get; set; }
    }
    public class intervalres
    {
        

        public int intervals { get; set; }

        public int number { get; set; }
    }

    public class Data
    {
        public string Queue_Name { get; set; }

        public int count_peop { get; set; }

        public int percent_peop { get; set; }
    }
    public class Queue
    {
        public List<Data> queue { get; set; }
    }

    public class ThresholdQueue
    {
        public List<intervalres> inter { get; set; }
    }




    public class Result
    {
        public string result { get; set; }
    }

}

