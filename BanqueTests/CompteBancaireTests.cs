using CompteBanqueNS;

namespace BanqueTests;

[TestClass]
public class CompteBancaireTests
{
    [TestMethod]
    public void VérifierDébitCompteCorrect()
    {
        //Ouvrir un compte
        double soldeInitial = 500000;
        double montantDébit = 400000; //Montant débit correct
        //double montantDébit = 800000;    //Montant du débit supérieur au solde
        double soldeAttendu = 100000;
        var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

        //Débiter
        compte.Débiter(montantDébit);

        //Tester
        double soldeObtenu = compte.Balance;
        Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte débité incorrectement");
    }


    [TestMethod]
    [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
    //[ExpectedException(typeof(System.ApplicationException))]
    public void DébiterMontantNégatifLèveArgumentOutOfRang()
    {
        //Ouvrir un compte
        double soldeInitial = 500000;
        double montantDébit = -400000; //Montant débit négatif
        double soldeAttendu = 100000;
        var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

        //Débiter
        compte.Débiter(montantDébit);

        //Tester
        double soldeObtenu = compte.Balance;
        Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte débité incorrectement");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void DébiterMontantSupérieurSoldeLèveArgumentOutOfRange()
    {
        //Ouvrir un compte
        double soldeInitial = 500000;
        double montantDébit = 800000; //Montant débit supérieur au solde
        double soldeAttendu = 100000;
        var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

        //Débiter
        compte.Débiter(montantDébit);

        //Tester
        double soldeObtenu = compte.Balance;
        Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte débité incorrectement");
    }
    
}