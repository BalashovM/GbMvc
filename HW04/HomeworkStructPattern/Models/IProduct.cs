using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Models
{
    public interface IProduct
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }
}
