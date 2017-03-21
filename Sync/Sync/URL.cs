using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync
{
    class URL
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string BrowserName { get; set; }


        public URL(string url, string title, string Browsname)
        {

            Url = url;
            Title = title;
            BrowserName = Browsname;
    
        }
    }
}
