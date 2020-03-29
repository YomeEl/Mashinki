using SFML.Graphics;
using SFML.System;

namespace Mashinki.UI
{
    interface IMenuElement
    {
        bool Selected { get; set; }
        FloatRect GlobalBounds { get; }

        void Draw(RenderWindow win);
    }
}
