using CursedIsland.StartMenu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CursedIsland
{
    public struct GameManager
    {
        private bool menu;
        private bool level;

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

        private GameManager _gameManager;
        private TitleScreen titleScreen = new TitleScreen();
        //private GameLevel gameLevel = new GameLevel();

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
            titleScreen.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            titleScreen.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _gameManager.Level = true;

            // TODO: Add your update logic here

            if (_gameManager.Menu)
                titleScreen.Update(gameTime);
            //else
                //gameLevel.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            // TODO: Add your drawing code here

            if (_gameManager.Menu)
                titleScreen.Draw(_spriteBatch, gameTime);
            //else
                //gameLevel.Draw(_spriteBatch, gameTime);



            base.Draw(gameTime);
        }
    }
}