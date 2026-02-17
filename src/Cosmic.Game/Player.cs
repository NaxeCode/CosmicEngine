using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicEngine
{
    internal class Player
    {

        public string Asset { get; }
        public int X { get; set; }
        public int Y { get; set; }
        Texture2D playerTexture;
        Vector2 playerPosition;

        public Player(string asset, int x, int y)
        {
            if (string.IsNullOrWhiteSpace(asset))
                throw new ArgumentException("Asset is required.", nameof(asset));
            Asset = asset;
            X = x;
            Y = y;

            
            playerPosition = new Vector2(X, Y);
        }
    }
}
