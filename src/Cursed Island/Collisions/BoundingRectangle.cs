using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CursedIsland.Collisions
{
    public struct BoundingRectangle
    {
        public float X, Y, Width, Height;

        public float Left => X;
        public float Right => X + Width;
        public float Top => Y;
        public float Bottom => Y + Height;


        public BoundingRectangle (float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public BoundingRectangle (Vector2 pos,  float width, float height)
        {
            X = pos.X;
            Y = pos.Y;

            Width = width;
            Height = height;
        }

        public bool CollidesWith (BoundingRectangle other)
        {   
            return CollisionHelper.Collides (this, other);
        }

        public bool CollidesWith(BoundingCircle other)
        {
            return CollisionHelper.Collides(other, this);
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch _spriteBatch)
        {
            // Load a 1x1 pixel texture to represent the rectangle
            Texture2D rectangleTexture = new Texture2D(graphicsDevice, 1, 1);
            rectangleTexture.SetData(new Color[] { Color.White });

            // Set the initial position and size of the rectangle
            Rectangle rectanglePosition = new Rectangle((int) X, (int) Y, (int) Width, (int) Height);

            _spriteBatch.Draw(rectangleTexture, rectanglePosition, Color.Red);

        }
    }
}
