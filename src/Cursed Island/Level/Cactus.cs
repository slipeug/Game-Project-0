using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CursedIsland.Collisions;

namespace CursedIsland.Level
{
    public class Cactus : AnimatedSprite
    {
        private BoundingRectangle bounds;

        public BoundingRectangle Bounds => bounds;

        public Cactus(Vector2 position) 
        {
            base.scale = 0.2f;
            base.position = position;
            this.bounds = new BoundingRectangle(position.X + 20, position.Y + 20, 300 * scale, 300 * scale);
        }

        public void LoadContent(ContentManager content)
        {
            LoadContent(content, "cactus", 100f);
        }
        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            bounds.Draw(graphicsDevice, spriteBatch);
            base.Draw(graphicsDevice, spriteBatch, Color.White);
        }

    }
}
