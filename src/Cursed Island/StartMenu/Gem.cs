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
            base.scale = 0.8f;
            this.bounds = new BoundingCircle(new Vector2(position.X + 25 * scale, position.Y + 25 * scale), 15 * scale);
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
            Draw(graphicsDevice, spriteBatch, Color.White);
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
