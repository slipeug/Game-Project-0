using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CursedIsland
{
    public enum EnemyType
    {
        PoisonSpider
    }

    public class Enemy : AnimatedSprite
    {
        float viewAngle;
        float viewDistance;
        float speed;

        List<Vector2> trajectoryPoints;
        Vector2 lastTrajectoryPosition;
        Vector2 followPosition;

        bool outOfTrajectory = false;
        bool followingPlayer = false;

        int point = 0;

        EnemyType enemyType;


        public Enemy(float viewAngle, float viewDistance, EnemyType enemyType, float speed, List<Vector2> trajectoryPoints)
        {
            this.viewAngle = viewAngle;
            this.viewDistance = viewDistance;
            this.enemyType = enemyType;
            this.speed = speed;
            this.trajectoryPoints = trajectoryPoints;
        }

        public void LoadContent(ContentManager content)
        {
            LoadContent(content, enemyType.ToString(), 100f);
        }

        public void Update(float deltaTime, Vector2 playerPosition)
        {
            position = new Vector2 (30, 30);

            //position += speed * deltaTime * direction;

            //if (!outOfTrajectory)
            //{
            //    // if we have reached the trajectory point is the next one has to be considered
            //    if (trajectoryPoints[point] == position)
            //    {
            //        point++;

            //        // if the trajectory point is the last one, the list should be reversed and 
            //        // we have to start from the second point in that list
            //        if (point == trajectoryPoints.Count - 1)
            //        {
            //            point = 1;
            //            trajectoryPoints.Reverse();
            //        }

            //        followPosition = trajectoryPoints[point];

            //        // calculate the new direction for the enemy to follow the trajectory point
            //        direction = trajectoryPoints[point] - position;
            //    }
            //}


            //Vector2 vectorToPlayer = playerPosition - trajectoryPoints[point];

            //// Calculate the angle between the two vectors in radians
            //float angleRadians = (float)Math.Atan2(vectorToPlayer.Y - direction.Y, vectorToPlayer.X - direction.X);
            //// Convert the angle from radians to degrees
            //float angleDegrees = MathHelper.ToDegrees(angleRadians);

            //if (angleDegrees <= viewAngle / 2 && Vector2.Distance(trajectoryPoints[point], position) <= viewDistance)
            //{
            //    followPosition = playerPosition;
            //}
            //else
            //{
            //    followPosition = lastTrajectoryPosition;
            //    outOfTrajectory = true;
            //}

        }

        public void Draw (GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Color color, float scale)
        {
            base.Draw(graphicsDevice, spriteBatch, color, scale);
        }

    }
}
