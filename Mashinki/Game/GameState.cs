using System.Collections.Generic;

using SFML.System;

namespace Mashinki.Game
{
    class GameState
    {
        public List<Factory> Factories { get; }
        public List<Truck> Trucks { get; }
        public uint Tick { get; private set; }

        public GameState()
        {
            Tick = 0;

            Factories = new List<Factory>();
            Trucks = new List<Truck>();

            Factories.Add(new Factory(PrototypeManager.GetPrototype("Bank"), new Vector2f(100, 100)));
            Factories.Add(new Factory(PrototypeManager.GetPrototype("GoldMine"), new Vector2f(200, 200)));

            Trucks.Add(new Truck(PrototypeManager.GetPrototype("BlueTruck"), new Vector2f(50, 50)));
        }

        public void NextTick()
        {
            Tick++;
        }
    }
}
