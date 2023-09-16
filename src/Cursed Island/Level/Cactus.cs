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
        const float size = 0.2f;
        private BoundingRectangle bounds = new BoundingRectangle(0, 0, 512 * size, 512 * size);

        public BoundingRectangle Bounds => bounds;

        public Cactus(Vector2 position) 
        {
            base.position = position;
        }

        public void LoadContent(ContentManager content)
        {
            LoadContent(content, "cactus", 100f);
        }

        public void Update(GameTime gameTime)
        {
            bounds.X = position.X;
            bounds.Y = position.Y;
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            base.Draw(graphicsDevice, spriteBatch, Color.White, size);
        }

    }
}
