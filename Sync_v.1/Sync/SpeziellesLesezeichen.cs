using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync
{
    class SpeziellesLesezeichen : Chronik
    {
        public string Text { get; set; }

        public SpeziellesLesezeichen(string txt, string url)
        {

            Text = txt;
            Url = url;            

        }

       
         
    }
}
