using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;




namespace CursedIsland.StartMenu
{
    public static class GlobalVariables
    {
        public static int WINDOW_WIDTH = 1152;
        public static int WINDOW_HEIGHT = 648;
    }
    public class TitleScreen : Scene
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MainMenu _mainMenu;
        private StartMenuBackground _background;

        private Gem _gem;
        private Spider _spider;
        private Skull _skull;


        public override void Initialize(ContentManager content)
        {
            _background = new StartMenuBackground();
            _mainMenu = new MainMenu();
            _gem = new Gem(new Vector2(840, 175));
            _spider = new Spider();
            _skull = new Skull();
        }

        public override void LoadContent(ContentManager content, Game game = null)
        {
            _mainMenu.LoadContent(content);
            _background.LoadContent(content);
            _gem.LoadContent(content);
            _spider.LoadContent(content);
            _skull.LoadContent(content);
        }

        public override void Update(GameTime gameTime, GameManager gameManager, InputManager inputManager)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            _background.Update(gameTime);
            _gem.Update(gameTime);
            _spider.Update(gameTime);
            _skull.Update(gameTime);

        }

        public override void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            _background.Draw(spriteBatch);
            _mainMenu.Draw(gameTime, spriteBatch);
            _gem.Draw(graphicsDevice, spriteBatch);
            _spider.Draw(graphicsDevice, spriteBatch);
            _skull.Draw(graphicsDevice, spriteBatch);

        }
    }
}