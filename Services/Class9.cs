using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class Class9
    {
        public string Message { set; get; }
        public int id { set; get; }
        public String Status { set; get; }
        public String type { set; get; }
        public String Host { set; get; }

        public Class9(String m,int i,String s,String t,String h) {
            this.Message = m;
            this.id = i;
            this.Status = s;
            this.type = t;
            this.Host = h;
        }
        
    }
}