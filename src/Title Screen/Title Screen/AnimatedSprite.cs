using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TitleScreen
{
    public class AnimatedSprite
    {
        protected Vector2 position = new Vector2(20, 20);
        private Texture2D texture;

        //private Vector2 sourceRectangle;
        private int frameCount;
        private int currentFrame;
        private float timeSinceLastFrame;
        private float animationTime;

         
        public void LoadContent(ContentManager content, string fileName, float time)
        {
            texture = content.Load<Texture2D>(fileName);
            frameCount = texture.Width / texture.Height;
            currentFrame = 0;
            animationTime = time;
        }


        public void Update (GameTime gameTime)
        {
            timeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceLastFrame > animationTime)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timeSinceLastFrame -= animationTime;
            }
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            Rectangle sourceRec = new Rectangle(currentFrame * texture.Height, 0, texture.Height, texture.Height);

            spriteBatch.Draw(texture, position, sourceRec, Color.White);
        }

    }
}
