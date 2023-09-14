using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Xna.Framework.Input;

namespace CursedIsland.StartMenu
{
    public class Skull : AnimatedSprite
    {
        public void LoadContent(ContentManager content)
        {
            position = new Vector2(295, 245);
            LoadContent(content, "catrina", 0.07f);
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float scale = 0.23f;
            Draw(spriteBatch, Color.Orange, scale);
        }
    }
}
