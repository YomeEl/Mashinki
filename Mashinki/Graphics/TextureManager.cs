using System.Collections.Generic;

using SFML.Graphics;

namespace Mashinki.Graphics
{
    static class TextureManager
    {
        private static readonly Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
        private static readonly Texture ErrorTexture = new Texture("Splines/ErrorTexture.png");

        public static void AddTexture(string prototypename, string path)
        {
            textures.Add(prototypename, new Texture(path));
        }

        public static Texture GetTexture(string name)
        {
            if (textures.ContainsKey(name))
            {
                return textures[name];
            }
            else
            {
                return ErrorTexture;
            }
        }
    }
}
