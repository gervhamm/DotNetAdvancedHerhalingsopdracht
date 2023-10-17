using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvancedHerhalingsopdracht.Model
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }

        private Byte _age;
        public Byte Age
        {
            get { return _age; }
            set
            {
                if (17 < value && value < 100)
                {
                    _age = value;
                }
            }
        }

        public override string? ToString()
        {
            return String.Format("FirstName: {0}, LastName: {1}", FirstName,LastName);
        }
    }
}
