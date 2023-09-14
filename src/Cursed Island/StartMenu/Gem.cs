using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CursedIsland.StartMenu
{
    public class Gem : AnimatedSprite
    {
        public void LoadContent(ContentManager content)
        {
            position = new Vector2(840, 175);
            LoadContent(content, "icons8-sparkling-diamond", 0.03f);
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.White, 0.8f);
        }
    }
}
