using SFML.System;
using SFML.Graphics;

namespace Mashinki.UI
{
    class TextButton : RectangleShape, IMenuElement
    {
        public string Text { get; set; }
        public Color SelectedColor { get; set; }
        public Color DefaultColor { get; set; }
        public Color DisabledColor { get; set; } = new Color(128, 128, 128);
        public bool Enabled { get; set; }
        public bool Selected { get; set; } = false;

        public delegate void ClickAction();
        public ClickAction OnClick = null;

        private bool firstDraw = true;
        private Text text;
        private FloatRect textBounds;

        public FloatRect GlobalBounds { get; private set; }

        public void Draw(RenderWindow win)
        {
            if (firstDraw)
            {
                text = new Text(Text, new Font(Properties.Resources.ARIALUNI))
                {
                    FillColor = Color.Black,
                    Position = this.Position
                };
                textBounds = text.GetGlobalBounds();
                GlobalBounds = GetGlobalBounds();
                text.Position += new Vector2f((GlobalBounds.Width - textBounds.Width) / 2, (GlobalBounds.Height - textBounds.Height - text.CharacterSize / 2) / 2);
                firstDraw = false;
            }

            FillColor = Enabled ? Selected ? SelectedColor : DefaultColor : DisabledColor;

            win.Draw(this);
            win.Draw(text);
        }
    }
}
