using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace Mashinki.UI
{
    class MenuPage
    {
        public Dictionary<string, IMenuElement> Elements { get; } = new Dictionary<string, IMenuElement>();
        public bool Active { get; private set; }

        private IMenuElement selectedElement;
        private readonly RenderWindow win;

        public MenuPage(RenderWindow win)
        {
            this.win = win;
        }

        public void Draw()
        {
            var mousePosition = Mouse.GetPosition(win);

            foreach (IMenuElement element in Elements.Values)
            {
                if (element.GlobalBounds.Contains(mousePosition.X, mousePosition.Y))
                {
                    element.Selected = true;
                    selectedElement = element;
                }
                else
                {
                    element.Selected = false;
                    if (selectedElement == element)
                    {
                        selectedElement = null;
                    }
                }

                element.Draw(win);
            }
        }

        public void Activate()
        {
            win.MouseButtonPressed += MouseButtonPressed;
            Active = true;
        }

        public void Deactivate()
        {
            win.MouseButtonPressed -= MouseButtonPressed;
            Active = false;
        }

        private void MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                if (selectedElement is TextButton)
                {
                    if (((TextButton)selectedElement).Enabled && ((TextButton)selectedElement).OnClick != null)
                    { 
                        ((TextButton)selectedElement).OnClick();
                    }
                }
            }
        }
    }
}
