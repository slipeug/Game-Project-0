using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CursedIsland.Level
{
    public class GameLevel : Scene
    {
        private MainCharacter _mainCharacter = new MainCharacter();
        //private List<Spider> _spiders;

        public override void Initialize()
        {
        }
        public override void LoadContent(ContentManager content)
        {
            _mainCharacter.LoadContent(content);
        }
        public override void Update(GameTime gameTime, InputManager inputManager)
        {
            _mainCharacter.Update(gameTime, inputManager);
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _mainCharacter.Draw(spriteBatch);
        }
    }
}
