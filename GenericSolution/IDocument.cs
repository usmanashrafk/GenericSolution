﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GenericSolution
{
    public interface IDocument<T> 
    {
        T GenerateDocument();
    }
}
