namespace AdHocMigrator.Tests
{
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class MigrazioneTests
    {
        [Test]
        public void GruppiTest()
        {
            var gruppi = new MigrazioneGruppi();
            Assert.AreEqual(true, gruppi.Esporta());
        }

        [Test]
        public void UtentiTest()
        {
            var utenti = new MigrazioneUtenti();
            Assert.AreEqual(true, utenti.Esporta());
        }

        [Test]
        public void CategorieTest()
        {
            var categorie = new MigrazioneCategorie();
            Assert.AreEqual(true, categorie.Esporta());
        }

        [Test]
        public void ProdottiTest()
        {
            var migrazione = new MigrazioneProdotti();
            Assert.AreEqual(true, migrazione.Esporta());
        }

        [Test]
        public void PrezziTest()
        {
            var prezzi = new MigrazionePrezzi();
            Assert.AreEqual(true, prezzi.Esporta());
        }

        [Test]
        public void PrezziSpecialiTest()
        {
            var prezzi = new MigrazionePrezziSpeciali();
            Assert.AreEqual(true, prezzi.Esporta());
        }

        [Test]
        public void DeleteUserTest()
        {
            var utenti = new MigrazioneUtenti();
            utenti.DeleteUser("Codice1");
        }

        [Test]
        public void DeleteGroupTest()
        {
            var gruppi = new MigrazioneGruppi();
            gruppi.DeleteGroup("GA");
        }
    }
}