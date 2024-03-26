using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados.Anticorruption.Tradução
{
    public class Tradutor
    {
        public IDictionary<string, string> storedTraductions { get; set; }
        public Tradutor()
        {
            storedTraductions = new Dictionary<string, string>();
        }
        public void AddTraduction(string key, string value)
        {
            storedTraductions.Add(key, value);
        }

        public bool IsEmpty()
        {
            return storedTraductions.Count == 0;
        }

        public string Traduzir(string word)
        {
            return storedTraductions.Where(x => x.Key.Equals(word)).Select(x => x.Value).FirstOrDefault();
        }
    }
}
