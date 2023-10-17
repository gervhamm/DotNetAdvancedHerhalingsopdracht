using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvancedHerhalingsopdracht.Model
{
    [TableName(Name = "Students")]
    public class Student : Person
    {
        public Int16 Year { get; set; }
    }

    
}
