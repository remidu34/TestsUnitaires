using TestsUnitaires;
using Xunit;

namespace TestsUnitairesXunit
{
    public class ApiTests
    {
        [Fact(DisplayName = "On vérifie qu'un serveur ait un CA à 0")]
        public void TestValuesCreateServeur()
        {
            // Arrange
            var client = new Api();

            // Act
            var response = client.GetServeur();

            // Assert
            var value = response;
            Assert.NotEmpty(value.name);
            Assert.Equal(0, value.ChiffreAffaire);
        }

        [Fact(DisplayName = "On vérifie qu'un serveur ait un CA à 25€ après une commande")]
        public void TestValuesCommandeServeur()
        {
            // Arrange
            var client = new Api();

            // Act
            var response = client.GetServeurCommande();

            // Assert
            var value = response;
            Assert.NotEmpty(value.name);
            Assert.Equal(25, value.ChiffreAffaire);
        }

        [Fact(DisplayName = "On vérifie qu'un serveur ait un CA à 100€ après avoir repris une commande")]
        public void TestValuesRecommandeServeur()
        {
            // Arrange
            var client = new Api();

            // Act
            var response = client.GetServeurRecommande();

            // Assert
            var value = response;
            Assert.NotEmpty(value.name);
            Assert.Equal(100, value.ChiffreAffaire);
        }
    }
}
