using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using CursedIsland.StartMenu;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Collections;


namespace CursedIsland.Level
{
    public class GameLevel : Scene
    {
        const string filePath = "savedGame.dat";


        private MainCharacter _mainCharacter = new MainCharacter();
        //private List<Spider> _spiders;

        private Portal _startPortal = new Portal(new Vector2(-20, 0), true);
        private Portal _finishPortal = new Portal(new Vector2(GlobalVariables.WINDOW_WIDTH - 100, GlobalVariables.WINDOW_HEIGHT - 130));

        private List<Cactus> _cactuses = new List<Cactus>();
        private List<Gem> _gems = new List<Gem>();
        private int _gemsAmount = 10;
        private int _gemsCollected = 0;
        private List<Crystal3D> _crystalLives = new List<Crystal3D>();
        private int _livesAmount = 5;
        private int _livesLeft = 5;
        private SoundEffect _ouchSound;
        private SoundEffectInstance _ouchSoundInstance;
        private Random random = new Random();

        private Tilemap _tileMap;

        public override void Initialize(ContentManager content)
        {
            _livesLeft = 5;
            _gemsCollected = 0;

            for (int i = 0; i < 10; i++)
            {
                Cactus c = new Cactus(
                    new Vector2(
                        random.Next(20, GlobalVariables.WINDOW_WIDTH - 50),
                        random.Next(20, GlobalVariables.WINDOW_HEIGHT - 50)
                    )
                );
                c.LoadContent( content );
                _cactuses.Add(c);
            }

        }


        public void Serialize()
        {
            List<int> arr = new List<int>();

            foreach (var c in _cactuses)
            {
                arr.Add((int)c.position.X);
                arr.Add((int)c.position.Y);
            }

            try
            {
                string outputString = string.Join(" ", arr); // Convert the array to a space separated string

                File.WriteAllText(filePath, outputString);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while writing to the file: " + e.Message);
            }
        }

        private void Deserialize()
        {
            // Open the file for reading
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine(); // Read a line from the file

                if (line != null)
                {
                    // Split the line into individual integers
                    int[] integers = line.Split(' ').Select(int.Parse).ToArray();

                    // Now, you have an array of integers from the file
                    if (integers.Length % 2 == 0)
                    {
                        for (int i = 0; i < integers.Length; i += 2)
                        {
                            int firstNumber = integers[i];
                            int secondNumber = integers[i + 1];

                            _cactuses.Add(new Cactus(
                                new Vector2(
                                    firstNumber,
                                    secondNumber
                                )
                            ));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The file is empty or reached the end.");
                }
            }
        }

        public void Reset (ContentManager content, Game game)
        {
            _cactuses.Clear();
            Initialize(content);
        }

        public override void LoadContent(ContentManager content, Game game)
        {
            if (File.Exists(filePath))
            {
                _cactuses.Clear();
                this.Deserialize();
            }

            for (int i = 0; i < _gemsAmount; i++)
            {
                Gem g;
                do
                {
                    g = new Gem(
                        new Vector2(
                            random.Next(20, GlobalVariables.WINDOW_WIDTH - 50),
                            random.Next(20, GlobalVariables.WINDOW_HEIGHT - 50)
                        )
                    );
                }
                while (
                    g.NotCollide(_cactuses) ||
                    g.Bounds.CollidesWith(_mainCharacter.Bounds) ||
                    g.Bounds.CollidesWith(_startPortal.Bounds) ||
                    g.Bounds.CollidesWith(_finishPortal.Bounds)
                );

                g.LoadContent(content);
                _gems.Add(g);
            }

            for (int i = 0; i < _livesAmount; i++)
            {
                _crystalLives.Add(new Crystal3D(game.GraphicsDevice, new Vector2((float)(3 + i), -3.5f)));
            };

            foreach (var c in _cactuses)
            {
                c.LoadContent(content);
            }

            _tileMap = content.Load<Tilemap>("tiles");
            _mainCharacter.LoadContent(content, game);
            _startPortal.LoadContent(content);
            _finishPortal.LoadContent(content);
            _ouchSound = content.Load<SoundEffect>("ouch");

            _ouchSoundInstance = _ouchSound.CreateInstance();
        }

        public override void Update(GameTime gameTime, GameManager gameManager, InputManager inputManager)
        {
            _startPortal.Update(gameTime);
            _finishPortal.Update(gameTime);
            _mainCharacter.Update(gameTime, inputManager);

            foreach (var c in _crystalLives)
            {
                c.Update(gameTime);
            }

            foreach (var c in _cactuses)
            {
                if (c.Bounds.CollidesWith(_mainCharacter.Bounds))
                {
                    _ouchSoundInstance.Play();
                    _livesLeft--;
                    _mainCharacter.Reset();

                    if (_livesLeft == 0)
                    {
                        gameManager.restart = true;
                        return;
                    }
                }
            }

            foreach (var g in _gems)
            {
                if (g.Bounds.CollidesWith(_mainCharacter.Bounds))
                {
                    //_ouchSoundInstance.Play();
                    _gemsCollected++;
                    _gems.Remove(g);
                    break;
                }
            }

        }
        public override void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameTime gameTime)
        {
            _tileMap.Draw(gameTime, spriteBatch);

            _startPortal.Draw(graphicsDevice, spriteBatch);
            _finishPortal.Draw(graphicsDevice, spriteBatch);
            _mainCharacter.Draw(gameTime, graphicsDevice, spriteBatch);

            foreach (var c in _cactuses)
            {
                c.Draw(graphicsDevice, spriteBatch);
            }

            foreach (var g in _gems)
            {
                g.Draw(graphicsDevice, spriteBatch);
            }
        }

        public void Draw3d(GraphicsDevice graphicsDevice)
        {
            for (int i = _livesAmount - 1; i >= _livesAmount - _livesLeft; i--)
            {
                _crystalLives[i].Draw(graphicsDevice);
            }
        }
    }
}
