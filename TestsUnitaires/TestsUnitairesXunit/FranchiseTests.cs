using System;
using TestsUnitaires;
using Xunit;

namespace LeGrandRestaurant.Test
{
    public class FranchiseTests
    {
        [Theory(DisplayName = "ÉTANT DONNÉ une franchise ayant X restaurants de Y serveurs chacuns" +
                            "QUAND tous les serveurs prennent une commande d'un montant Z" +
                            "ALORS le chiffre d'affaires de la franchise est X * Y * Z")]
        [InlineData(0, 0, 1.0, 0)]
        [InlineData(1, 1, 1.0, 1)]
        [InlineData(2, 2, 1.0, 4)]
        [InlineData(1000, 1000, 1.0, 1000000)]
        public void ServeurPrennentCommandeDansFranchise(int x, int y, float z, float expected)
        {
            // ÉTANT DONNE une franchise ayant X restaurants
            var tables = new Table[] { new Table() };
            var serveurs = new Serveur[] { new Serveur() };
            var restaurants = new Restaurant[x];
            for (int i = 0; i < x; i++)
            {
                restaurants[i] = new Restaurant(tables, serveurs);
            }

            // QUAND tous les serveurs prennent une commande d'un montant Z
            foreach (var restaurant in restaurants)
            {
                foreach (var serveur in restaurant.getServeurs())
                {
                    serveur.PrendCommande(y);
                }
            }

            // ALORS le chiffre d'affaires de la franchise est X * Y * Z
            var result = x * y * z;
            Assert.Equal(expected, result);
        }
    }
}
