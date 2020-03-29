using SFML.Graphics;
using SFML.System;

using Mashinki.Game;

namespace Mashinki.Graphics
{
    class Engine
    {
        private readonly RenderWindow win;
        private IntRect screenRect;
        private float scale = 1f;
        private GameState gameState;
        private Vector2f cameraPosition;

        public Engine(RenderWindow win)
        {
            this.win = win;
            LoadPrototypes();
            gameState = new GameState();
            screenRect = new IntRect(0, 0, (int)win.Size.X, (int)win.Size.Y);
            cameraPosition = new Vector2f(0, 0);
        }

        private void LoadPrototypes()
        {
            PrototypeManager.AddPrototype("Factories");
            PrototypeManager.AddPrototype("Trucks");
        }

        private IntRect ToIntRect(FloatRect floatRect)
        {
            return new IntRect((int)floatRect.Left, (int)floatRect.Top, (int)floatRect.Height, (int)floatRect.Width);
        }

        private bool OnScreen(FloatRect floatRect)
        {
            return screenRect.Intersects(ToIntRect(floatRect));
        }

        public void Draw()
        {
            var rs = new RectangleShape();

            //Draw Roads

            foreach (Factory factory in gameState.Factories)
            {
                rs.Texture = TextureManager.GetTexture(factory.Type);
                rs.Size = factory.Size * scale;
                rs.Position = (factory.Position - cameraPosition) * scale - rs.Size / 2;

                win.Draw(rs);
            }

            foreach (Truck truck in gameState.Trucks)
            {
                rs.Texture = TextureManager.GetTexture(truck.Type);
                rs.Size = truck.Size * scale;
                rs.Position = (truck.Position - cameraPosition) * scale - rs.Size / 2;
                rs.TextureRect = new IntRect(0, 0, (int)rs.Texture.Size.X, (int)rs.Texture.Size.Y);
                win.Draw(rs);
            }

            //Draw UI
        }

        public void Run()
        {
            while (win.IsOpen)
            {
                win.Clear(Color.White);
                Draw();
                win.Display();
                win.DispatchEvents();
            }
        }
    }
}
