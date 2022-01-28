using System.Collections.Generic;

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
