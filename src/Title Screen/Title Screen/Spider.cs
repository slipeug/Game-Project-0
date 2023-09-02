using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TitleScreen
{
    public class Spider : AnimatedSprite
    {
        public void LoadContent(ContentManager content)
        {
            base.LoadContent(content, "spider", 100f);
        }

        public void Update(GameTime gameTime)
        {
            float heightDiff = - (float) Math.Cos(gameTime.TotalGameTime.TotalSeconds) * 100;
            base.position = new Vector2(1000, heightDiff);

            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch, 0.15f);
        }
    }
}
