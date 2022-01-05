using System.Collections.Generic;

namespace TestsUnitaires
{
    public class Franchise
    {
        private readonly Menu _menu;

        public Franchise(Restaurant restaurant)
        {
            _menu = new Menu();
            restaurant.ImposerMenu(_menu);
        }

        public void FixerPrix(Plat plat, decimal nouveauPrix)
            => _menu.FixerPrix(plat, nouveauPrix);
    }
}
