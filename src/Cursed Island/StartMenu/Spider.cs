using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;

namespace CursedIsland.StartMenu
{
    public class Spider : AnimatedSprite
    {
        public void LoadContent(ContentManager content)
        {
            base.scale = 0.15f;
            LoadContent(content, "spider", 100f);
        }

        public void Update(GameTime gameTime)
        {
            float heightDiff = -(float)Math.Cos(gameTime.TotalGameTime.TotalSeconds) * 100;
            position = new Vector2(1000, heightDiff);

            base.Update(gameTime);
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            Draw(graphicsDevice, spriteBatch, Color.White);

            Vector2 origin = new Vector2(
                position.X + texture.Width / 2 * scale,
                position.Y + texture.Height / 2 * scale
            );
            spriteBatch.DrawLine(
origin, new Vector2(position.X + texture.Width / 2 * scale, 0f), Color.Black, 2
            );

        }
    }
}
