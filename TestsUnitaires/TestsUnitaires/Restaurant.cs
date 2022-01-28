using System.Collections.Generic;
using System.Linq;

namespace TestsUnitaires
{
    public class Restaurant
    {
        private readonly Table[] _tables;
        private readonly Serveur[] _serveurs;
        private Menu _menu;

        public Restaurant(Table[] tables, Serveur[] serveurs)
        {
            _tables = tables;
            _serveurs = serveurs;
            _menu = new Menu();
        }

        public Serveur[] getServeurs()
        {
            return _serveurs;
        }

        public void DébuterService(Maitre maitre, Table[] tables)
        {
            foreach(var table in tables)
            {
                maitre.PrendTable(table);
            }
        }

        public bool LaTableEstLibre(Table table)
            => table.EstLibre;

        public void TerminerService()
        {
            foreach (var table in _tables)
            {
                table.Libérer();
            }
        }

        public IEnumerable<Table> RechercherTablesLibres()
        {
            return _tables.Where(m => m.EstLibre);
        }

        public decimal ObtenirPrix(Plat plat) => _menu.ObtenirPrix(plat);

        public void FixerPrix(Plat plat, decimal prixRestaurant)
            => _menu.FixerPrix(plat, prixRestaurant);

        internal void ImposerMenu(Menu menu)
        {
            _menu = new MenuFranchisé(menu);
        }
    }
}
