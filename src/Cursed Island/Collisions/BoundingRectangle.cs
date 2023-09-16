﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

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
    }
}
