using System;
using TestsUnitaires;
using Xunit;

namespace LeGrandRestaurant.Test
{
    public class ServeurTests
    {
        [Fact(DisplayName = "ÉTANT DONNÉ un nouveau serveur " +
                            "QUAND on récupére son chiffre d'affaires " +
                            "ALORS celui-ci est à 0")]
        public void ServeurEqual0()
        {
            // ÉTANT DONNÉ un nouveau serveur
            Serveur serveur = new Serveur();
            // QUAND on récupére son chiffre d'affaires
            int ChiffreAffaire = serveur.ChiffreAffaire;
            // ALORS celui-ci est à 0
            Assert.Equal(0, ChiffreAffaire);
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un nouveau serveur " +
                            "QUAND il prend une commande " +
                            "ALORS son chiffre d'affaires est le montant de celle-ci")]
        public void ServeurEqual()
        {
            // ÉTANT DONNÉ un nouveau serveur
            Serveur serveur = new Serveur();
            // QUAND il prend une commande
            serveur.PrendCommande();
            int ChiffreAffaire = serveur.ChiffreAffaire;
            int Montant = serveur.Montant;
            // ALORS son chiffre d'affaires est le montant de celle-ci
            Assert.Equal(Montant, ChiffreAffaire);
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un serveur ayant déjà pris une commande " +
                            "QUAND il prend une nouvelle commande " +
                            "ALORS son chiffre d'affaires est la somme des deux commandes")]
        public void ServeurSumCommand()
        {
            // ÉTANT DONNÉ un serveur ayant déjà pris une commande
            Serveur serveur = new Serveur();
            serveur.PrendCommande();

            // QUAND il prend une nouvelle commande
            serveur.PrendCommande();
            int ChiffreAffaire = serveur.ChiffreAffaire;
            int Montant = serveur.Montant;
            // ALORS son chiffre d'affaires est la somme des deux commandes
            Assert.Equal(ChiffreAffaire, Montant * 2);
        }
    }
}
