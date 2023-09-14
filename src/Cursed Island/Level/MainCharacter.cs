using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CursedIsland.Level
{
    public class MainCharacter : AnimatedSprite
    {
        public void LoadContent(ContentManager content)
        {
            LoadContent(content, "jungle_person", 0.1f, 8, 1);
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            float speed = 50 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.position += inputManager.Direction * speed;

            base.Update(gameTime, inputManager);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float scale = 3f;
            Draw(spriteBatch, Color.White, scale);
        }
    }
}
