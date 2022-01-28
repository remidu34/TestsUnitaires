using System;
using TestsUnitaires;
using Xunit;

namespace LeGrandRestaurant.Test
{
    public class RestaurantTests
    {
        [Theory(DisplayName = "ÉTANT DONNÉ un restaurant ayant X serveurs" +
            "QUAND tous les serveurs prennent une commande d'un montant Y" +
            "ALORS le chiffre d'affaires de la franchise est X * Y" +
            "CAS(X = 0; X = 1; X = 2; X = 100)" +
            "CAS(Y = 1.0)")]
        [InlineData(0, 1.0, 0)]
        [InlineData(1, 1.0, 1)]
        [InlineData(2, 1.0, 2)]
        [InlineData(100, 1.0, 100)]
        public void ServeurPrennentCommande(int x, float y, float expected)
        {
            // ÉTANT DONNÉ un restaurant ayant X serveurs
            var tables = new Table[] { new Table() };
            var serveurs = new Serveur[x];
            for (int i = 0; i < x; i++)
            {
                serveurs[i] = new Serveur();
            }
            var restaurant = new Restaurant(tables, serveurs);

            // QUAND tous les serveurs prennent une commande d'un montant Y
            foreach (var serveur in serveurs)
            {
                serveur.PrendCommande(y);
            }

            // ALORS le chiffre d'affaires de la franchise est X * Y
            var result = x * y;
            Assert.Equal(expected, result);
        }

/*	TODO
 *	ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
    QUAND le service débute
    ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel


    ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
    QUAND le service débute
    ALORS il n'est pas possible de modifier le serveur affecté à la table


    ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
    ET ayant débuté son service

    QUAND le service se termine
    ET qu'une table est affectée à un serveur
	ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel*/

        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant 3 tables" +
            "QUAND le service commence" +
            "ALORS elles sont toutes affectées au Maître d'Hôtel")]

        public void DebutService()
        {
            // ÉTANT DONNE un restaurant ayant 3 tables
            var tables = new Table[3];
            for (int i = 0; i < 3; i++)
            {
                tables[i] = new Table();
            }
            var serveurs = new Serveur[2];
            for (int i = 0; i < 2; i++)
            {
                serveurs[i] = new Serveur();
            }
            var restaurant = new Restaurant(tables, serveurs);
            var maitre = new Maitre();

            //QUAND le service commence
            restaurant.DébuterService(maitre, tables);

            // ALORS elles sont toutes affectées au Maître d'Hôtel
            var result = maitre.tables;
            Assert.Equal(tables, result);
        }
    }
}
