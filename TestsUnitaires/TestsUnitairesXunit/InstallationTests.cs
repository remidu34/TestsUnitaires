using System;
using System.Linq;
using Xunit;

namespace LeGrandRestaurant.Test
{
    public class InstallationTests
    {
        [Fact(DisplayName = "ÉTANT DONNE une table dans un restaurant ayant débuté son service " +
                            "QUAND un client est affecté à une table " +
                            "ALORS cette table n'est plus libre")]
        public void AffectationClient()
        {
            // ÉTANT DONNE une table dans un restaurant ayant débuté son service
            var tables = new Table[] { new Table() };
            var serveurs = new Serveur[] { new Serveur() };
            var restaurant = new Restaurant(tables, serveurs);
            restaurant.DébuterService();

            // QUAND un client est affecté à une table
            tables[0].InstallerClient();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.False(tables[0].EstLibre);
        }

        [Fact(DisplayName = "ÉTANT DONNE une table occupée par un client " +
                            "QUAND la table est libérée " +
                            "ALORS cette table est libre")]
        public void DesaffectationClient()
        {
            // ÉTANT DONNE une table occupée par un client
            var tables = new Table[] { new Table() };
            var serveurs = new Serveur[] { new Serveur() };
            var restaurant = new Restaurant(tables, serveurs);

            restaurant.DébuterService();
            tables[0].InstallerClient();

            // QUAND la table est libérée
            tables[0].Libérer();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.True(tables[0].EstLibre);
        }

        [Fact(DisplayName = "ÉTANT DONNE une table occupée par un client " +
                            "QUAND on veut installer un client " +
                            "ALORS une exception est lancée")]
        public void AlreadyPresentClient()
        {
            // ÉTANT DONNE une table occupée par un client
            var table = new Table();
            table.InstallerClient();

            // QUAND on veut installer un client
            void Act() => table.InstallerClient();

            // ALORS une exception est lancée
            Assert.Throws<InvalidOperationException>(Act);
        }

        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant une table occupée par un client " +
                            "QUAND le service est terminé " +
                            "ALORS elle est libérée")]
        public void ServiceEnd()
        {
            // ÉTANT DONNE un restaurant ayant une table occupée par un client
            var tables = new Table[] { new Table() };
            var serveurs = new Serveur[] { new Serveur() };
            var restaurant = new Restaurant(tables, serveurs);
            tables[0].InstallerClient();

            // QUAND le service est terminé
            restaurant.TerminerService();

            // ALORS elle est libérée
            Assert.True(tables[0].EstLibre);
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant deux tables, dont une occupée " +
                            "QUAND on recherche une table " +
                            "ALORS la table encore libre est renvoyée")]
        public void NextFreeTable()
        {
            // ÉTANT DONNÉ un restaurant ayant deux tables, dont une occupée
            var tables = new Table[] { new Table(), new Table() };
            var serveurs = new Serveur[] { new Serveur() };
            tables[0].InstallerClient();

            var restaurant = new Restaurant(tables, serveurs);

            // QUAND on recherche une table
            var tableChoisie = restaurant
                .RechercherTablesLibres()
                .Single();

            // ALORS la table encore libre est renvoyée
            Assert.Same(tableChoisie, tables[1]);
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant deux tables, toutes occupées " +
                            "QUAND on recherche une table libre" +
                            "ALORS une collection vide est renvoyée")]
        public void NoFreeTable()
        {
            // ÉTANT DONNÉ un restaurant ayant deux tables, toutes occupées
            var tableOccupées = new Table[] { new Table(), new Table() };
            var serveurs = new Serveur[] { new Serveur() };
            foreach (var tableOccupée in tableOccupées)
                tableOccupée.InstallerClient();

            var restaurant = new Restaurant(tableOccupées, serveurs);

            // QUAND on recherche une table libre
            var tablesLibres = restaurant.RechercherTablesLibres();

            // ALORS une collection vide est renvoyée
            Assert.Empty(tablesLibres);
        }
    }
}
