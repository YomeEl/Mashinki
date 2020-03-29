using SFML.Graphics;
using SFML.System;

namespace Mashinki.UI
{
    static class MenuPageGenerator
    {
        public static MenuPage GetMainPage(RenderWindow win)
        {
            var windowSize = win.Size;
            var page = new MenuPage(win);

            page.Elements["LoadButton"] = new TextButton()
            {
                Text = "Load game",
                DefaultColor = Color.Red,
                SelectedColor = Color.Yellow,
                OutlineColor = Color.Black,
                OutlineThickness = 2,
                Position = new Vector2f(windowSize.X * 0.12f, windowSize.Y * 0.5f),
                Size = new Vector2f(windowSize.X * 0.32f, windowSize.Y * 0.08f),
                Enabled = false
            };
            page.Elements["NewGameButton"] = new TextButton()
            {
                Text = "New game",
                DefaultColor = Color.Red,
                SelectedColor = Color.Yellow,
                OutlineColor = Color.Black,
                OutlineThickness = 2,
                Position = new Vector2f(windowSize.X * 0.12f, windowSize.Y * 0.6f),
                Size = new Vector2f(windowSize.X * 0.32f, windowSize.Y * 0.08f),
                Enabled = true,
                OnClick = page.Deactivate
            };
            page.Elements["SettingsButton"] = new TextButton()
            {
                Text = "Settings",
                DefaultColor = Color.Red,
                SelectedColor = Color.Yellow,
                OutlineColor = Color.Black,
                OutlineThickness = 2,
                Position = new Vector2f(windowSize.X * 0.12f, windowSize.Y * 0.7f),
                Size = new Vector2f(windowSize.X * 0.32f, windowSize.Y * 0.08f),
                Enabled = true
            };
            page.Elements["ExitButton"] = new TextButton()
            {
                Text = "Exit",
                DefaultColor = Color.Red,
                SelectedColor = Color.Yellow,
                OutlineColor = Color.Black,
                OutlineThickness = 2,
                Position = new Vector2f(windowSize.X * 0.12f, windowSize.Y * 0.8f),
                Size = new Vector2f(windowSize.X * 0.32f, windowSize.Y * 0.08f),
                Enabled = true,
                OnClick = win.Close
            };

            return page;
        }
    }
}
