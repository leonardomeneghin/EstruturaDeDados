using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados.Anticorruption.DataStructures.Pilha
{
    public class PilhaVaziaException : Exception
    {
        public PilhaVaziaException(string message) : base(message)
        {
            
        }
    }
}
