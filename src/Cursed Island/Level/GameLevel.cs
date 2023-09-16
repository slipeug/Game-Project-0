using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using CursedIsland.StartMenu;

namespace CursedIsland.Level
{
    public class GameLevel : Scene
    {
        private MainCharacter _mainCharacter = new MainCharacter();
        //private List<Spider> _spiders;

        private List<Cactus> _cactuses = new List<Cactus>();

        private Random random = new Random();


        public override void Initialize(ContentManager content)
        {
            for(int i = 0; i < 10; i++)
            {
                _cactuses.Add(new Cactus(
                    new Vector2(
                        random.Next(20, GlobalVariables.WINDOW_WIDTH),
                        random.Next(20, GlobalVariables.WINDOW_HEIGHT)
                    )
                ));
            }

            foreach (var c in _cactuses)
            {
                c.LoadContent(content);
            }
        }

        public void Reset (ContentManager content)
        {
            _mainCharacter.Reset();
            _cactuses.Clear();
            Initialize(content);
        }

        public override void LoadContent(ContentManager content)
        {
            foreach(var c in _cactuses)
            {
                c.LoadContent(content);
            }

            _mainCharacter.LoadContent(content);
        }
        public override void Update(GameTime gameTime, GameManager gameManager, InputManager inputManager)
        {
            _mainCharacter.Update(gameTime, inputManager);

            foreach (var c in _cactuses)
            {
                c.Update(gameTime);
            }


            foreach (var c in _cactuses)
            {
                if (c.Bounds.CollidesWith(_mainCharacter.Bounds))
                {
                    gameManager.restart = true;
                    return;
                }
            }
        }
        public override void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var c in _cactuses)
            {
                c.Draw(graphicsDevice, spriteBatch);
            }


            _mainCharacter.Draw(graphicsDevice, spriteBatch);
        }
    }
}
