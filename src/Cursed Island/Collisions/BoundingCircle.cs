using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CursedIsland.Collisions
{
    public struct BoundingCircle
    {
        public Vector2 Center;
        public float Radius;
        
        public BoundingCircle (Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool CollidesWith(BoundingCircle other)
        {
            return CollisionHelper.Collides(this, other);
        }

        public bool CollidesWith (BoundingRectangle other)
        {
            return CollisionHelper.Collides (this, other);
        }

        public void Draw (GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {

            //int radius = (int)Radius;
            //Texture2D texture = new Texture2D(graphicsDevice, radius, radius);
            //Color[] colorData = new Color[radius * radius];

            //float diam = radius / 2f;
            //float diamsq = diam * diam;

            //for (int x = 0; x < radius; x++)
            //{
            //    for (int y = 0; y < radius; y++)
            //    {
            //        int index = x * radius + y;
            //        Vector2 pos = new Vector2(x - diam, y - diam);
            //        if (pos.LengthSquared() <= diamsq)
            //        {
            //            colorData[index] = Color.White;
            //        }
            //        else
            //        {
            //            colorData[index] = Color.Transparent;
            //        }
            //    }
            //}

            //texture.SetData(colorData);
            //spriteBatch.Draw(texture, Center, Color.Red);

            DrawCircle(spriteBatch, Center, Radius, Color.Red);

        }

        private void DrawCircle(SpriteBatch spriteBatch, Vector2 center, float radius, Color color, int segments = 100)
        {
            float angleIncrement = MathHelper.TwoPi / segments;

            for (int i = 0; i < segments; i++)
            {
                float angle = angleIncrement * i;
                float x = center.X + radius * (float)Math.Cos(angle);
                float y = center.Y + radius * (float)Math.Sin(angle);

                Vector2 point1 = new Vector2(x, y);

                angle = angleIncrement * (i + 1);
                x = center.X + radius * (float)Math.Cos(angle);
                y = center.Y + radius * (float)Math.Sin(angle);

                Vector2 point2 = new Vector2(x, y);

                spriteBatch.DrawLine(point1, point2, color, 1);
            }
        }
    }

}
