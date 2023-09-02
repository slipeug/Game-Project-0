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
        protected Texture2D texture;

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

        public void Draw (SpriteBatch spriteBatch, Color color = default(Color), float scale = 1f)
        {
            if (color == default(Color))
                color = Color.White;

            Rectangle sourceRec = new Rectangle(currentFrame * texture.Height, 0, texture.Height, texture.Height);
            spriteBatch.Draw(texture, position, sourceRec, color, 0f, new Vector2(0f,0f), scale, SpriteEffects.None, 0);
        }

    }
}
