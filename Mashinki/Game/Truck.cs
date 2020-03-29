using System;

using SFML.System;

namespace Mashinki.Game
{
    class Truck
    {
        public string Type { get; }
        public Vector2f Size { get; }
        public Vector2f Position { get; }
        public float Speed { get; }

        private const uint validPrototypeLength = 4;

        public Truck(string[] prototype, Vector2f position)
        {
            if (prototype.Length != validPrototypeLength)
            {
                throw new Exception("Invalid prototype!");
            }
            Type = prototype[0];
            var width = float.Parse(prototype[1]);
            var height = float.Parse(prototype[2]);
            var speed = float.Parse(prototype[3]);
            Size = new Vector2f(width, height);
            Speed = speed;
            Position = position;
        }
    }
}
