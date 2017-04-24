using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Diagnostics.Debug;

namespace Sync
{
    class Chronik
    {
        public string Url { get; set; }

        public Chronik(string url)
        {
            Url = url;
        }

       public Chronik()
        {

        }

        public override string ToString()
        {
            return Url;
        }

      
    }
}


