using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados.Anticorruption.StringHandler
{
    interface ICamelCaseHandler
    {
        public List<string> ConverterCamelCase(string palavra);
    }
}
