using FluentAssertions;
using System.Collections.Generic;
using TestsUnitaires;
using Xunit;

namespace TestsUnitairesXunit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IEnumerable<int> numbers = new[] { 1, 2, 3 };

            numbers.Should().OnlyContain(n => n > 0);
            numbers.Should().HaveCount(3, "parce que nous pensions avoir mis quatre articles dans la collection");
        }

        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant le statut de filiale d'une franchise " +
                            "QUAND la franchise modifie le prix du plat au menu " +
                            "ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise")]
        public void GetFranchise()
        {
            var tables = new Table[] { new Table() };
            var serveurs = new Serveur[] { new Serveur() };
            var restaurant = new Restaurant[] { new Restaurant(tables, serveurs) };
            var franchise = new Franchise(restaurant);

            var nouveauPrix = new decimal(67.99);
            var plat = new Plat();

            franchise.FixerPrix(plat, nouveauPrix);

            // ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise
            var prixDuPlat = restaurant[0].ObtenirPrix(plat);

            prixDuPlat.Should().Equals(nouveauPrix);


        }
    }
}