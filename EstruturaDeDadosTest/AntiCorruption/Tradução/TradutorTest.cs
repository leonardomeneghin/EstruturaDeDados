using EstruturaDeDados.Anticorruption.Tradução;
namespace EstruturaDeDadosTest.AntiCorruption.Tradução
{
    public class TradutorTest
    {
        private Tradutor _tradutor;
        [SetUp]
        public void SetUp()
        {
            _tradutor = new Tradutor();
        }
        [Test]
        public void TraductorIsEmpty()
        {
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(true));
        }
        [Test]
        public void TraductOneTimeGood()
        {
            _tradutor.AddTraduction("bom", "good");


            Assert.That(_tradutor.Traduzir("bom"), Is.EqualTo("good"));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }
        [Test]
        public void TraductOneTimeBad()
        {
            _tradutor.AddTraduction("ruim", "bad");


            Assert.That(_tradutor.Traduzir("ruim"), Is.EqualTo("bad"));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }
        [Test]
        public void TraductTwoWords()
        {
            _tradutor.AddTraduction("ruim", "bad");
            _tradutor.AddTraduction("bom", "good");


            Assert.That(_tradutor.Traduzir("ruim"), Is.EqualTo("bad"));
            Assert.That(_tradutor.Traduzir("bom"), Is.EqualTo("good"));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }
    }
}
