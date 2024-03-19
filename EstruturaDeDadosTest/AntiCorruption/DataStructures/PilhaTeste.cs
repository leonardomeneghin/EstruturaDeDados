using EstruturaDeDados.Anticorruption.DataStructures.Pilha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDadosTest.AntiCorruption.DataStructures
{
    public class PilhaTeste
    {
        Pilha p;
        [SetUp]
        public void SetUp()
        {
            p = new Pilha(10);
        }
        [TestCase]
        public void PilhaVazia()
        {
            Assert.That(p.isVazia(), Is.EqualTo(true));
            Assert.That(p.Quantidade, Is.EqualTo(0));
        }
        [TestCase]
        public void EmpilharUmElemento()
        {
            p.Empilhar("first");
            Assert.That(p.isVazia(), Is.EqualTo(false));
            Assert.That(p.Quantidade, Is.EqualTo(1));
            Assert.That(p.Topo(), Is.EqualTo("first"));
        }
        [TestCase]
        public void EmpilharDoisDesempilhaUm()
        {
            p.Empilhar("first");
            p.Empilhar("seccond");
            Assert.That(p.Quantidade, Is.EqualTo(2));
            Assert.That(p.Topo(), Is.EqualTo("seccond"));
            
            Object desempilhado = p.Desempilha();
            Assert.That(p.Quantidade, Is.EqualTo(1));
            Assert.That(p.Topo(), Is.EqualTo("first"));
            Assert.That(desempilhado, Is.EqualTo("seccond"));
        }
        [TestCase]
        public void PilhaVaziaException()
        {
             //Esperado um erro, pois a pilha não tem elementos
            Assert.Throws<PilhaVaziaException>(() =>
            {
                p.Desempilha();
            });
        }
        [TestCase]
        public void PilhaCheiaException()
        {
            for (int i = 0; i < 10; i++)
            {
                p.Empilhar(i);
            }
            Assert.Throws<PilhaCheiaException>(() =>
            {
                p.Empilhar(11);
            });
        }
    }
}
