using CursedIsland.StartMenu;
using CursedIsland.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CursedIsland
{
    public class GameManager
    {
        private bool menu = true;
        private bool level = false;
        public bool restart = false;

        public bool Menu
        {
            get { return menu; }
            set
            {
                menu = value;
                level = !menu;
            }
        }

        public bool Level
        {
            get { return level; }
            set
            {
                level = value;
                menu = !level;
            }
        }

    }


    public class CursedIsland : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private InputManager _inputManager = new InputManager();
        private GameManager _gameManager = new GameManager();
        private TitleScreen titleScreen = new TitleScreen();
        private GameLevel gameLevel = new GameLevel();

        public CursedIsland()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Set the desired window size here
            _graphics.PreferredBackBufferWidth = GlobalVariables.WINDOW_WIDTH; // Width in pixels
            _graphics.PreferredBackBufferHeight = GlobalVariables.WINDOW_HEIGHT; // Height in pixels
            _graphics.ApplyChanges();

            _gameManager.Menu = true;
            titleScreen.Initialize(Content);
            gameLevel.Initialize(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            titleScreen.LoadContent(Content);
            gameLevel.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            _inputManager.Update(gameTime);

            if (_inputManager.Exit)
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                _gameManager.Level = true;

            // TODO: Add your update logic here

            if (_gameManager.restart)
            {
                _gameManager.Menu = true;
                _gameManager.restart = false;
                gameLevel.Reset(Content);
            }
            else if (_gameManager.Menu)
            {
                titleScreen.Update(gameTime, _gameManager, _inputManager);
            }
            else
            {
                gameLevel.Update(gameTime, _gameManager, _inputManager);
            }

           base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            _spriteBatch.Begin();
            
            if (_gameManager.Menu)
                titleScreen.Draw(GraphicsDevice, _spriteBatch, gameTime);
            else
                gameLevel.Draw(GraphicsDevice, _spriteBatch, gameTime);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}