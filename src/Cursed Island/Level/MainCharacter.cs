﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CursedIsland.Collisions;
using CursedIsland.StartMenu;
using CursedIsland.Particles;

namespace CursedIsland.Level
{
    public class MainCharacter : AnimatedSprite, IParticleEmitter
    {
        const float scale = 3f;
        private static readonly Vector2 InitPos = new Vector2(20, 20);

        private BoundingRectangle bounds = new BoundingRectangle(0, 0, 23 * scale, 34 * scale);

        public BoundingRectangle Bounds => bounds;

        public Vector2 Position { get { return position + new Vector2(bounds.Width / 2, bounds.Height - 5); }  }
        public Vector2 Velocity { get; private set; }

        private DirtParticleSystem _dirt;

        public void LoadContent(ContentManager content, Game game)
        {
            position = InitPos;
            _dirt = new DirtParticleSystem(game, this);
            _dirt.LoadContent();
            LoadContent(content, "jungle_person", 0.1f, 8, 1);
        }

        public void Reset()
        {
            position = InitPos;
            //_dirt.LoadContent();
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            _dirt.Update(gameTime);

            float speed = 50 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Velocity = inputManager.Direction;

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

        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            Draw(graphicsDevice, spriteBatch, Color.White, scale);
            _dirt.Draw(gameTime);
        }
    }
}
