using SFML.Graphics;

namespace Mashinki.UI
{
    class Menu
    {
        private MenuPage activePage;

        public void Run(RenderWindow win)
        {
            var mainPage = MenuPageGenerator.GetMainPage(win);
            activePage = mainPage;
            activePage.Activate();

            while (win.IsOpen && activePage.Active)
            {
                win.Clear(Color.White);
                activePage.Draw();
                win.Display();

                win.WaitAndDispatchEvents();
            }
        }
    }
}
