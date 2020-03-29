using System.Collections.Generic;
using System.IO;

using Mashinki.Graphics;

namespace Mashinki.Game
{
    static class PrototypeManager
    {
        private static readonly Dictionary<string, string[]> prototypes = new Dictionary<string, string[]>();

        public static void AddPrototype(string prototypeName)
        {
            var lines = File.ReadLines($"{prototypeName}/{prototypeName}.txt");
            foreach (string line in lines)
            {
                if (line[0] != '#')
                {
                    var elements = line.Split(' ');
                    var typename = elements[0];
                    TextureManager.AddTexture(typename, $"{prototypeName}/{typename}.png");
                    prototypes.Add(typename, elements);
                }
            }
        }

        public static string[] GetPrototype(string name)
        {
            return prototypes[name];
        }
    }
}
