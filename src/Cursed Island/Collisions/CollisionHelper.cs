using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CursedIsland.Collisions
{
    public static class CollisionHelper
    {
        /// <summary>
        /// Detects collision between two bounding circles
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool Collides(BoundingCircle a, BoundingCircle b)
        {
            return Math.Pow(a.Radius + b.Radius, 2) >=
                Math.Pow(a.Center.X - b.Center.X, 2) + 
                Math.Pow(a.Center.Y - b.Center.Y, 2);
        }

        public static bool Collides(BoundingRectangle a, BoundingRectangle b)
        {
            return ! 
                (
                    a.Right < b.Left || 
                    a.Left > b.Right ||
                    a.Top > b.Bottom ||
                    a.Bottom < b.Top
                );
        }

        public static bool Collides (BoundingCircle c, BoundingRectangle r)
        {
            double closestX = Math.Max(r.X, Math.Min(c.Center.X, r.X + r.Width));
            double closestY = Math.Max(r.Y, Math.Min(c.Center.Y, r.Y + r.Height));

            // Calculate the distance between the closest point and the circle's center
            double distance = Math.Sqrt(Math.Pow(c.Center.X - closestX, 2) + Math.Pow(c.Center.Y - closestY, 2));

            // If the distance is less than or equal to the circle's radius, there is an intersection
            return distance <= c.Radius;



            //float nearestX = MathHelper.Clamp(c.Center.X, r.Left, r.Right);
            //float nearestY = MathHelper.Clamp(c.Center.Y, r.Top, r.Bottom);

            //float distanceSquared = (nearestX - c.Center.X) * (nearestX - c.Center.X) +
            //                        (nearestY - c.Center.Y) * (nearestY - c.Center.Y);

            //return distanceSquared <= (c.Radius * c.Radius);
        }

        public static bool Collides(BoundingRectangle r, BoundingCircle c) => Collides(c, r);
    }
}
