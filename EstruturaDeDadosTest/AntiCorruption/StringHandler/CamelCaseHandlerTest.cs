using EstruturaDeDados.Anticorruption.StringHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDadosTest.AntiCorruption.StringHandler
{
    public class CamelCaseHandlerTest
    {
        private CamelCaseHandler _handler;
        [SetUp] public void SetUp()
        {
            _handler = new CamelCaseHandler();
        }
        [TestCase]
        public void OneWord()
        {
            string palavra = "nome";
            var listaPalavrasConvertidas = _handler.ConverterCamelCase(palavra);
            Assert.That(listaPalavrasConvertidas.Count, Is.EqualTo(1));
        }
        [TestCase]
        public void OneWordWithFirstCharUpper()
        {
            string palavra = "Nome";
            var listaPalavrasConvertidas = _handler.ConverterCamelCase(palavra);
            Assert.That(listaPalavrasConvertidas.Count, Is.EqualTo(1));
            Assert.That(listaPalavrasConvertidas.Contains(palavra.ToLower()), Is.EqualTo(true));
        }
        [TestCase]
        public void TwoWords()
        {
            string palavra = "nomeSobrenome";
            var listaPalavrasConvertidas = _handler.ConverterCamelCase(palavra);
            string word1 = palavra.Substring(0, 4).ToLower();
            string word2 = palavra.Substring(4, 9).ToLower();

            Assert.That(listaPalavrasConvertidas.Count, Is.EqualTo(2));
            Assert.That(listaPalavrasConvertidas.Contains(word1), Is.EqualTo(true));
            Assert.That(listaPalavrasConvertidas.Contains(word2), Is.EqualTo(true));
        }
        [TestCase]
        public void ThreeWords()
        {
            string palavra = "nomeSobrenomeComposto";
            var listaPalavrasConvertidas = _handler.ConverterCamelCase(palavra);
            string word1 = palavra.Substring(0, 4).ToLower();
            string word2 = palavra.Substring(4, 9).ToLower();
            string word3 = palavra.Substring(13, 8).ToLower();

            Assert.That(listaPalavrasConvertidas.Count, Is.EqualTo(3));
            Assert.That(listaPalavrasConvertidas.Contains(word1), Is.EqualTo(true));
            Assert.That(listaPalavrasConvertidas.Contains(word2), Is.EqualTo(true));
            Assert.That(listaPalavrasConvertidas.Contains(word2), Is.EqualTo(true));
        }
        [TestCase]
        public void OneWordWithCPF()
        {
            string palavra = "nomeCPF";
            var listaPalavrasConvertidas = _handler.ConverterCamelCase(palavra);
            string word1 = palavra.Substring(0, 4).ToLower();
            string word2 = palavra.Substring(4, 3).ToLower();


            Assert.That(listaPalavrasConvertidas.Count, Is.EqualTo(2));
            Assert.That(listaPalavrasConvertidas.Contains(word1), Is.EqualTo(true));
            Assert.That(listaPalavrasConvertidas.Contains(word2), Is.EqualTo(true));
        }
    }
}
