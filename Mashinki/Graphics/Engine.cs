using SFML.Graphics;
using SFML.System;
using SFML.Window;

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

        public void Draw()
        {
            var rs = new RectangleShape();

            //Draw Roads

            foreach (Factory factory in gameState.Factories)
            {
                rs.Size = factory.Size * scale;
                rs.Position = (factory.Position - cameraPosition) * scale - rs.Size / 2;
                if (screenRect.Intersects(ToIntRect(rs.GetGlobalBounds())))
                {
                    rs.Texture = TextureManager.GetTexture(factory.Type);
                    rs.TextureRect = new IntRect(0, 0, (int)rs.Texture.Size.X, (int)rs.Texture.Size.Y);
                    win.Draw(rs);
                }
            }

            foreach (Truck truck in gameState.Trucks)
            {
                rs.Size = truck.Size * scale;
                rs.Position = (truck.Position - cameraPosition) * scale - rs.Size / 2;
                if (screenRect.Intersects(ToIntRect(rs.GetGlobalBounds())))
                {
                    rs.Texture = TextureManager.GetTexture(truck.Type);
                    rs.TextureRect = new IntRect(0, 0, (int)rs.Texture.Size.X, (int)rs.Texture.Size.Y);
                    win.Draw(rs);
                }
            }

            //Draw UI
        }

        public void Run()
        {
            while (win.IsOpen)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    cameraPosition.X -= 1;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    cameraPosition.X += 1;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    cameraPosition.Y -= 1;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    cameraPosition.Y += 1;
                }
                win.Clear(Color.White);
                Draw();
                win.Display();
                win.DispatchEvents();
            }
        }
    }
}
