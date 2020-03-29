using SFML.Window;
using SFML.Graphics;

using Mashinki.UI;
using Mashinki.Graphics;

namespace Mashinki
{
    static class Program
    {
        public static void Main()
        {
            var win = new RenderWindow(new VideoMode(800, 600), "Test");
            win.SetFramerateLimit(60);
            win.Closed += Win_Closed;

            var menu = new Menu();
            menu.Run(win);
            var engine = new Engine(win);
            engine.Run();
        }

        private static void Win_Closed(object sender, System.EventArgs e)
        {
            RenderWindow win = (RenderWindow)sender;
            win.Close();
        }
    }
}
