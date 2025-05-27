﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class Employee
    {
        public int id { get; set; }
        public string idCard { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public virtual double calSalary()
        {
            return 4000000;
        }
        public override string ToString()
        {
            return id + "\t" + idCard + "\t" + Name + "\t" 
                + Birthday.ToString("dd/MM/yyyy") + "\t" + calSalary();
        }
    }
}
