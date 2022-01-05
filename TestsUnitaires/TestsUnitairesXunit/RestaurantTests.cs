using System;
using TestsUnitaires;
using Xunit;

namespace LeGrandRestaurant.Test
{
    public class RestaurantTests
    {
        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant X serveurs" +
            "QUAND tous les serveurs prennent une commande d'un montant Y" +
            "ALORS le chiffre d'affaires de la franchise est X * Y" +
            "CAS(X = 0; X = 1; X = 2; X = 100)" +
            "CAS(Y = 1.0)")]
        public void ServeurPrennentCommande()
        {
            // ÉTANT DONNÉ un restaurant ayant X serveurs
            var tables = new Table[] { new Table() };
            var serveurs = new Serveur[100];
            for (int i = 0; i < 100; i++)
            {
                serveurs[i] = new Serveur();
            }
            var restaurant = new Restaurant(tables, serveurs);
            int montant = 0;

            // QUAND tous les serveurs prennent une commande d'un montant Y
            foreach (var serveur in serveurs)
            {
                serveur.PrendCommande();
                montant += serveur.Montant;
            }

            // ALORS le chiffre d'affaires de la franchise est X * Y
            Assert.Equal(5000, montant);
        }
    }
}
