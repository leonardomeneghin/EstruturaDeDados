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


            Assert.That(_tradutor.Traduct("bom"), Is.EqualTo("good"));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }
        [Test]
        public void TraductOneTimeBad()
        {
            _tradutor.AddTraduction("ruim", "bad");


            Assert.That(_tradutor.Traduct("ruim"), Is.EqualTo("bad"));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }
        [Test]
        public void TraductTwoWords()
        {
            _tradutor.AddTraduction("ruim", "bad");
            _tradutor.AddTraduction("bom", "good");


            Assert.That(_tradutor.Traduct("ruim"), Is.EqualTo("bad"));
            Assert.That(_tradutor.Traduct("bom"), Is.EqualTo("good"));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }
        [Test]
        public void TwoTraductionsSameWord()
        {
            _tradutor.AddTraduction("ruim", "bad");
            _tradutor.AddTraduction("ruim", "poor");


            Assert.That(_tradutor.Traduct("ruim"), Is.EqualTo("bad, poor"));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }

        [Test]
        public void ThreeTraductionsSameWord()
        {
            _tradutor.AddTraduction("ruim", "bad");
            _tradutor.AddTraduction("ruim", "poor");
            _tradutor.AddTraduction("ruim", "inferior");


            Assert.That(_tradutor.Traduct("ruim"), Is.EqualTo("bad, poor, inferior"));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }

        [Test]
        public void TraductEntirePhrase()
        {
            var phrase = "";

            _tradutor.AddTraduction("guerra", "war");
            _tradutor.AddTraduction("é", "is");
            _tradutor.AddTraduction("ruim", "bad");


            Assert.That(_tradutor.TraductPhrase("guerra é ruim"), Is.EqualTo("war is bad"));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }

        [Test]
        public void TraductEntirePhraseTwoTraductionsAtSameWord()
        {
            var phrase = "";

            _tradutor.AddTraduction("guerra", "war");
            _tradutor.AddTraduction("é", "is");
            _tradutor.AddTraduction("ruim", "bad");
            _tradutor.AddTraduction("ruim", "poor");


            Assert.That(_tradutor.TraductPhrase("guerra é ruim"), Is.EqualTo("war is bad"));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }
        [Test]
        public void VerifyKeyValueNull()
        {
            var phrase = "";

            _tradutor.AddTraduction("nullValue", null);
            _tradutor.AddTraduction(null, "null is key");



            Assert.That(_tradutor.TraductPhrase("nullValue"), Is.EqualTo(null));
            Assert.That(_tradutor.IsEmpty(), Is.EqualTo(false));
        }
    }
}
