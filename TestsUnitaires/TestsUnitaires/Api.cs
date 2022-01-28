using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestsUnitaires
{
    public class Api : Controller
    {
        public Serveur GetServeur()
        {
            Serveur serveur = new Serveur();
            return serveur;
        }

        public Serveur GetServeurCommande()
        {
            Serveur serveur = new Serveur();
            serveur.PrendCommande(25);
            return serveur;
        }

        public Serveur GetServeurRecommande()
        {
            Serveur serveur = new Serveur();
            serveur.PrendCommande(25);
            serveur.PrendCommande(75);
            return serveur;
        }
    }
}
