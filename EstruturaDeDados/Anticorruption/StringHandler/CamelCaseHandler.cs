using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            ValidateStringChain(palavra);
            arrayPalavra = palavra.ToCharArray();
            LowerFirstAndLastChar(arrayPalavra);
            SplitWords(arrayPalavra);

            foreach (var item in new string(cadeiaPalavras).Split(","))
            {
                _listaPalavras.Add(item.ToLower());
            };
            


            return _listaPalavras;
        }

        private void ValidateStringChain(string palavra)
        {
            Regex specialChars = new Regex("[^A-Za-z0-9,]");
            if(specialChars.Match(palavra).Success)
                throw new InvalidOperationException("Cannot operate with special characters");
            int numParsed = 0;
            if (Int32.TryParse(palavra[0].ToString(), out numParsed))
                throw new InvalidOperationException("String-chain cannot begins with number");
        }

        public void LowerFirstAndLastChar(char[] palavra)
        {
            palavra[0] = char.ToLower(palavra[0]);
            palavra[palavra.Length -1] = char.ToLower(palavra[palavra.Length - 1]);
        }
        private bool VerifyNumberStringOrder(char[] arrayPalavra, int i)
        {
            int numParse = 0;
            bool isNumber = Int32.TryParse(arrayPalavra[i].ToString(), out numParse);
            if (i == 0)
            {
                return false;
            }
            //Actual is Number and previous was lower char
            if (isNumber && char.IsLower(arrayPalavra[i-1]))
                return true;
            //Actual is UpperChar and previos was number
            if (char.IsUpper(arrayPalavra[i]) && Int32.TryParse(arrayPalavra[i-1].ToString(), out numParse))
                return true;
            return false;
        }

        private void SplitWords(char[] arrayPalavra)
        {
            for (int i = 0; i < arrayPalavra.Length; i++)
            {
                if (char.IsUpper(arrayPalavra[i]) && char.IsLower(arrayPalavra[i - 1])
                    || VerifyNumberStringOrder(arrayPalavra, i))
                    cadeiaPalavras+= ",";
                cadeiaPalavras += (arrayPalavra[i].ToString());
            }
        }
    }
}
