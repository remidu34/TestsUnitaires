namespace TestsUnitaires
{
    public class Table
    {
        public bool EstLibre { get; private set; } = true;
        public Maitre maitre;
        public Serveur serveur;
        public bool EstBloque { get; set; } = false;

        public void PrendTableServeur(Serveur serveur)
        {
            if (EstBloque == false)
                this.serveur = serveur;
        }

        public void PrendTableMaitre(Maitre maitre)
        {
            if (EstBloque == false)
                this.maitre = maitre;
        }

        public void InstallerClient()
        {
            if (!EstLibre) throw new InvalidOperationException();
            EstLibre = false;
        }

        public void Libérer()
        {
            EstLibre = true;
        }
    }
}
