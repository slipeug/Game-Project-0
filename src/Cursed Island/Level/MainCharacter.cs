using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CursedIsland.Collisions;
using CursedIsland.StartMenu;

namespace CursedIsland.Level
{
    public class MainCharacter : AnimatedSprite
    {
        const float scale = 3f;
        private static readonly Vector2 InitPos = new Vector2(20, 20);

        private BoundingRectangle bounds = new BoundingRectangle(0, 0, 23 * scale, 34 * scale);

        public BoundingRectangle Bounds => bounds;

        public void LoadContent(ContentManager content)
        {
            position = InitPos;
            LoadContent(content, "jungle_person", 0.1f, 8, 1);
        }

        public void Reset()
        {
            position = InitPos;
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            float speed = 50 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 newPosition = position + inputManager.Direction * speed;
            if ( 
                    newPosition.X > 0 && 
                    newPosition.Y > 0 &&
                    newPosition.X + texture.Width / 8 * scale < GlobalVariables.WINDOW_WIDTH &&
                    newPosition.Y + texture.Height * scale < GlobalVariables.WINDOW_HEIGHT
            )
                position = newPosition;

            bounds.X = position.X;
            bounds.Y = position.Y;

            base.Update(gameTime, inputManager);
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            Draw(graphicsDevice, spriteBatch, Color.White, scale);
        }
    }
}
