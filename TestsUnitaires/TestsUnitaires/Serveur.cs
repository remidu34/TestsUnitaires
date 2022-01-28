namespace TestsUnitaires
{
    public class Serveur
    {
        public string name = "serveur";
        public bool ADebuteService { get; set; } = false;
        public bool APrisCommande { get; private set; } = false;
        public float ChiffreAffaire { get; set; } = 0;
        public int NombreCommande { get; set; } = 0;

        public void PrendCommande(float montant)
        {
            APrisCommande = true;
            NombreCommande += 1;
            ChiffreAffaire += montant;
        }
    }
}
