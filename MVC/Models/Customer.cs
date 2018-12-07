﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Customer
    {
        public string CustomerName
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public override string ToString()
        {
            return this.CustomerName + "_" + this.Address;
        }
    }
}