﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvancedHerhalingsopdracht
{
    [AttributeUsage(AttributeTargets.Class)]
    class TableNameAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
