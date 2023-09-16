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

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            base.Update(gameTime);
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            Draw(graphicsDevice, spriteBatch, Color.White, 0.8f);
        }
    }
}
