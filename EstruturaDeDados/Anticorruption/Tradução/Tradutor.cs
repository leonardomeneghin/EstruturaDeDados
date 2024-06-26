﻿using System;
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
            if (key is null || value is null)
                throw new ArgumentNullException(nameof(key))
                    ;
            if (storedTraductions.ContainsKey(key))
                storedTraductions[key] = Traduct(key) + ", " + value;
            else
                storedTraductions.Add(key, value);
        }

        public bool IsEmpty()
        {
            return storedTraductions.Count == 0;
        }

        public string Traduct(string word)
        {
            return storedTraductions
                .Where(x => x.Key.Equals(word))
                .Select(x => x.Value).FirstOrDefault();
        }

        public string TraductPhrase(string frase)
        {
            string[] words = frase.Split(" ");
            string traductedPhrase = "";
            foreach (string word in words)
            {
                string traducao = GetFirstTraduction(word);
                traductedPhrase += " " + traducao;
            }
            return traductedPhrase.Trim();
        }

        private string GetFirstTraduction(string word)
        {

            string traducao = Traduct(word);
            if (traducao.Contains(","))
                traducao = traducao.Substring(0, traducao.IndexOf(","));
            return traducao;
        }
    }
}
