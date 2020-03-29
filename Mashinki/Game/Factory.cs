using System;

using SFML.System;

namespace Mashinki.Game
{
    class Factory
    {
        public string Type { get; }
        public Vector2f Size { get; }
        public Vector2f Position { get; }

        private const uint validPrototypeLength = 3;
        
        public Factory(string[] prototype, Vector2f position)
        {
            if (prototype.Length != validPrototypeLength)
            {
                throw new Exception("Invalid prototype!");
            }
            Type = prototype[0];
            var width = float.Parse(prototype[1]);
            var height = float.Parse(prototype[2]);
            Size = new Vector2f(width, height);
            Position = position;
        }
    }
}
