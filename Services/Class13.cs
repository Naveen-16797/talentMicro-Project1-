using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class Class13
    {
        public int id { set; get; }
        public String Username { set; get; }

        public Class13(int i,String user)
        {
            id = i;
            Username = user;
        }
    }
}