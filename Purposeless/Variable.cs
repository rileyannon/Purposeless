using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposeless
{
    public enum VariableType
    {
        INT,
        STRING,
        DOUBLE
    }

    public class Variable
    {
        public string Identifier;
        public VariableType Type;

        //this is lazy coding but it WORKS
        public string StringVal;
        public int intVal;
        public double doubleVal;
    }
}
