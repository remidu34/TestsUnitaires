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


        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant 3 tables" +
            "QUAND le service commence" +
            "ALORS elles sont toutes affectées au Maître d'Hôtel")]

        public void DebutServiceAffectMaitreHotel()
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
            var result = new string[tables.Length];
            for (int i = 0; i < tables.Length; i++)
            {
                if (tables[i].serveur != null)
                {
                    result[i] = tables[i].serveur.name;
                }
                else if (tables[i].maitre != null)
                {
                    result[i] = tables[i].maitre.name;
                }
            }
            Assert.Equal("maitre", result[0]);
            Assert.Equal("maitre", result[1]);
            Assert.Equal("maitre", result[2]);
        }
        

        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur" +
            "QUAND le service débute" +
            "ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel")]

        public void DebutServiceAffectServEtMaitre()
        {
            // ÉTANT DONNE un restaurant ayant 3 tables dont une affectée à un serveur
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

            tables[0].PrendTableServeur(serveurs[0]);


            //QUAND le service commence
            restaurant.DébuterService(maitre, tables);

            // ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel
            var result = new string[tables.Length];
            for (int i = 0; i < tables.Length; i++)
            {
                if (tables[i].serveur != null)
                {
                    result[i] = tables[i].serveur.name;
                } else if (tables[i].maitre != null)
                {
                    result[i] = tables[i].maitre.name;
                }
            }   
            Assert.Equal("serveur", result[0]);
            Assert.Equal("maitre", result[1]);
            Assert.Equal("maitre", result[2]);
        }

        
        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur" +
            "QUAND le service débute" +
            "ALORS il n'est pas possible de modifier le serveur affecté à la table")]

        public void DebutServicePasModifAffectation()
        {
            // ÉTANT DONNE un restaurant ayant 3 tables dont une affectée à un serveur
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

            tables[0].PrendTableServeur(serveurs[0]);
            tables[0].EstBloque = true;


            //QUAND le service commence
            restaurant.DébuterService(maitre, tables);

            // ALORS il n'est pas possible de modifier le serveur affecté à la table
            var result = tables[0].EstBloque;
            
            Assert.True(result);
        }


        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur" +
            "ET ayant débuté son service" +
            "QUAND le service se termine" +
            "ET qu'une table est affectée à un serveur" +
            "ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel")]

        public void DebutServiceEditTable()
        {
            // ÉTANT DONNE un restaurant ayant 3 tables dont une affectée à un serveur
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

            tables[0].PrendTableServeur(serveurs[0]);

            // ET ayant débuté le service
            restaurant.DébuterService(maitre, tables);
            serveurs[0].ADebuteService = true;

            // QUAND le service se termine
            restaurant.TerminerService();

            // ET qu'une table est affectée à un serveur
            tables[0].PrendTableServeur(serveurs[0]);

            // ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel
            var result = new string[tables.Length];
            for (int i = 0; i < tables.Length; i++)
            {
                if (tables[i].serveur != null)
                {
                    result[i] = tables[i].serveur.name;
                }
                else if (tables[i].maitre != null)
                {
                    result[i] = tables[i].maitre.name;
                }
            }
            Assert.Equal("serveur", result[0]);
            Assert.Equal("maitre", result[1]);
            Assert.Equal("maitre", result[2]);
        }
    }
}
