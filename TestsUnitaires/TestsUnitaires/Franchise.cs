using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class Franchise
    {
        private readonly Menu _menu;

        public Franchise(Restaurant[] restaurants)
        {
            _menu = new Menu();
            foreach (var restaurant in restaurants)
            {
                restaurant.ImposerMenu(_menu);
            }
        }

        public void FixerPrix(Plat plat, decimal nouveauPrix)
            => _menu.FixerPrix(plat, nouveauPrix);
    }
}
