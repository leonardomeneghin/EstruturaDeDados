using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados.Anticorruption.StringHandler
{
    /// <summary>
    ///  Classe responsável por transformar uma cadeia de caracteres em CamelCase conforme:
    ///  http://pt.wikipedia.org/wiki/CamelCase
    /// </summary>
    public class CamelCaseHandler : ICamelCaseHandler
    {
        private List<string> _listaPalavras;
        private char[] arrayPalavra;
        private string cadeiaPalavras;
        public CamelCaseHandler()
        {
            _listaPalavras = new List<string>();
            cadeiaPalavras = "";
        }
        public List<string> ConverterCamelCase(string palavra)
        {
            arrayPalavra = palavra.ToCharArray();
            LowerFirstAndLastChar(arrayPalavra);
            SplitWords(arrayPalavra);

            foreach (var item in new string(cadeiaPalavras).Split(","))
            {
                _listaPalavras.Add(item.ToLower());
            };
            


            return _listaPalavras;
        }

        public void LowerFirstAndLastChar(char[] palavra)
        {
            palavra[0] = char.ToLower(palavra[0]);
            palavra[palavra.Length -1] = char.ToLower(palavra[palavra.Length - 1]);
        }
        private void SplitWords(char[] arrayPalavra)
        {
            
            for (int i = 0; i < arrayPalavra.Length; i++)
            {
                if (char.IsUpper(arrayPalavra[i]) && char.IsLower(arrayPalavra[i - 1]))
                    cadeiaPalavras+= ",";
                cadeiaPalavras += (arrayPalavra[i].ToString());
            }
        }
    }
}
