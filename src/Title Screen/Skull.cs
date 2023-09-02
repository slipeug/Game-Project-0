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

namespace TitleScreen
{
    public class Skull : AnimatedSprite
    {
        public void LoadContent(ContentManager content)
        {
            base.position = new Vector2(295, 245);
            base.LoadContent(content, "catrina", 0.07f);
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float scale = 0.23f;
            base.Draw(spriteBatch, Color.Orange, scale);
        }
    }
}
