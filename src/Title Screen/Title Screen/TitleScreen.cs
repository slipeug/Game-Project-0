using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;




namespace TitleScreen
{
    public static class GlobalVariables
    {
        public static int WINDOW_WIDTH = 1152;
        public static int WINDOW_HEIGHT = 648;
    }
    public class TitleScreen : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MainMenu _mainMenu;
        private Background _background;


        private Gem _gem;
        private Spider _spider;


        public TitleScreen()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _background = new Background();
            _mainMenu = new MainMenu();
            _gem = new Gem();
            _spider = new Spider();
            
            // Set the desired window size here
            _graphics.PreferredBackBufferWidth = GlobalVariables.WINDOW_WIDTH; // Width in pixels
            _graphics.PreferredBackBufferHeight = GlobalVariables.WINDOW_HEIGHT; // Height in pixels
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _mainMenu.LoadContent(Content);
            _background.LoadContent(Content);
            _gem.LoadContent(Content);
            _spider.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _background.Update(gameTime);
            _gem.Update(gameTime);
            _spider.Update(gameTime);

            base.Update(gameTime);
        }
            
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _background.Draw(_spriteBatch);
            _mainMenu.Draw(gameTime, _spriteBatch);
            _gem.Draw(_spriteBatch);
            _spider.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}