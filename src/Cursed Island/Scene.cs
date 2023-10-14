using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Net.Mime;
using CursedIsland.Level;

namespace CursedIsland
{
    public abstract class Scene
    {
        public abstract void Initialize(ContentManager content);
        public abstract void LoadContent(ContentManager content, Game game);
        public abstract void Update(GameTime gameTime, GameManager gameManager, InputManager inputManager);
        public abstract void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameTime gameTime);
    }
}