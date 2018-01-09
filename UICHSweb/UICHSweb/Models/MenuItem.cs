using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UICHSweb.Models
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Active { get; set; }
    }
}