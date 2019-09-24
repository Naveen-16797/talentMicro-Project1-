using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class Class10
    {
        public string Message { set; get; }
        public String Status { set; get; }
        public object Record { set; get; }
        public String type { set; get; }
        public String Host { set; get; }

        public Class10(String m, String s,object r, String t, String h)
        {
            this.Message = m;
            this.Status = s;
            this.Record = r;
            this.type = t;
            this.Host = h;
        }
    }
}