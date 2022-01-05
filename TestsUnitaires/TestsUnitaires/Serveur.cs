namespace TestsUnitaires
{
    public class Serveur
    {
        public bool APrisCommande { get; private set; } = false;
        public int Montant { get; set; } = 0;
        public int ChiffreAffaire { get; set; } = 0;
        public int NombreCommande { get; set; } = 0;

        public void PrendCommande()
        {
            APrisCommande = true;
            NombreCommande += 1;
            Montant = 50;
            ChiffreAffaire += 50;
        }
    }
}
