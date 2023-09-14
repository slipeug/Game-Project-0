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

namespace CursedIsland
{
    public class AnimatedSprite
    {
        protected Vector2 position = new Vector2(20, 20);
        protected Texture2D texture;

        private bool swapDirection = false;

        private int framesHorizontally;
        private int framesVertically;
        private int currentFrame;
        private float timeSinceLastFrame;
        private float animationTime;

         // used for animated textures where all tte frames are placed into one long stripe
        public void LoadContent(ContentManager content, string fileName, float time)
        {
            texture = content.Load<Texture2D>(fileName);
            framesHorizontally = texture.Width / texture.Height;
            framesVertically = 1;
            currentFrame = 0;
            animationTime = time;
        }

        // used for animated textures with different dimentions
        public void LoadContent(ContentManager content, string fileName, float time, int framesH, int framesV)
        {
            texture = content.Load<Texture2D>(fileName);
            framesHorizontally = framesH;
            framesVertically = framesV;
            currentFrame = 0;
            animationTime = time;
        }

        public void Update (GameTime gameTime, InputManager inputManager = null)
        {
            if (inputManager != null)
            {
                // if sprite is moving in the opposite direction, swap it
                if (inputManager.Direction.X < 0)
                    swapDirection = true;
                else if (inputManager.Direction.X > 0)
                    swapDirection = false;
            }


            timeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceLastFrame > animationTime)
            {
                currentFrame = (currentFrame + 1) % (framesHorizontally * framesVertically);
                timeSinceLastFrame -= animationTime;
            }
        }

        public void Draw (SpriteBatch spriteBatch, Color color = default(Color), float scale = 1f)
        {
            if (color == default(Color))
                color = Color.White;

            int frameWidth = texture.Width / framesHorizontally;
            int frameHeight = texture.Height / framesVertically;

            int frameX = currentFrame % framesHorizontally;
            int frameY = currentFrame / framesHorizontally;


            Rectangle sourceRec = new Rectangle(frameX * frameWidth, frameY * frameHeight, frameWidth, frameHeight);
            SpriteEffects effects = swapDirection ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(texture, position, sourceRec, color, 0f, new Vector2(0f,0f), scale, effects, 0);
        }
    }
}
