using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvancedHerhalingsopdracht.Model
{
    [TableName (Name = "Teachers")]
    public class Teacher : Person
    {
        private string[] course;
        public string[] Course
        {
            get { return course ; } 
            set 
            { 
                course = value; 
                Course1 = value[0];
                if(value.Length > 1) { Course2 = value[1]; }
                
            }
        }

        public string? Course1 { get; private set; }
        public string? Course2 { get; private set;}
       
    }
}
