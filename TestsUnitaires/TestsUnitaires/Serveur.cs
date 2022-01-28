using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class Serveur
    {
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
