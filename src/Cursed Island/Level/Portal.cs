using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CursedIsland.Collisions;


namespace CursedIsland.Level
{
    public class Portal : AnimatedSprite
    {
        private BoundingRectangle bounds;

        public BoundingRectangle Bounds => bounds;

        public Portal(Vector2 position, bool swapDirection = false)
        {
            base.swapDirection = swapDirection;
            base.scale = 1.3f;
            base.position = position;
            this.bounds = new BoundingRectangle(position.X + 35 * scale, position.Y + 25 * scale, 35 * scale, 65 * scale);
        }

        public void LoadContent(ContentManager content)
        {
            LoadContent(content, "portal", 0.1f, 9, 1);
        }
        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            bounds.Draw(graphicsDevice, spriteBatch);
            base.Draw(graphicsDevice, spriteBatch, Color.White);
        }
    }
}
