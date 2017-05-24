using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Material
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }

    }
}