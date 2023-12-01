using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursedIsland.Collisions;
using CursedIsland.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CursedIsland.StartMenu
{
    public class Gem : AnimatedSprite
    {
        private BoundingCircle bounds;

        public BoundingCircle Bounds => bounds;
        public Gem (Vector2 position)
        {
            base.position = position;
            this.bounds = new BoundingCircle(new Vector2(position.X, position.Y), 40);
        }
        public void LoadContent(ContentManager content)
        {
            LoadContent(content, "icons8-sparkling-diamond", 0.03f);
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            base.Update(gameTime);
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            Bounds.Draw(graphicsDevice, spriteBatch);
            Draw(graphicsDevice, spriteBatch, Color.White, 0.8f);
        }

        public bool NotCollide (List<Cactus> cactuses)
        {
            foreach (var c in cactuses)
                if (c.Bounds.CollidesWith(Bounds))
                    return true;

            return false;
        }
    }
}
