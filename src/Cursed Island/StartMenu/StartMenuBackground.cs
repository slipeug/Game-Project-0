using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace CursedIsland.StartMenu
{

    public class StartMenuBackground
    {
        private Texture2D mainBackground;
        private Texture2D clouds1;
        private Texture2D clouds2;
        private Texture2D clouds3;

        public float Width { get; private set; }
        public float Height { get; private set; }

        float clouds1Pos = 0;
        float clouds2Pos = 0;
        float clouds3Pos = 0;

        public void LoadContent(ContentManager content)
        {
            mainBackground = content.Load<Texture2D>("1");
            clouds1 = content.Load<Texture2D>("2");
            clouds2 = content.Load<Texture2D>("3");
            clouds3 = content.Load<Texture2D>("4");
        }

        public void Update(GameTime gameTime)
        {
            clouds1Pos = (float)Math.Cos(gameTime.TotalGameTime.TotalSeconds) * 10;
            clouds2Pos = (float)Math.Cos(gameTime.TotalGameTime.TotalSeconds + 5) * 10;
            clouds3Pos = (float)Math.Cos(gameTime.TotalGameTime.TotalSeconds + 10) * 10;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mainBackground, new Vector2(0, 0), null, Color.White, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0);
            spriteBatch.Draw(clouds1, new Vector2(clouds1Pos, 0), null, Color.White, 0f, new Vector2(20, 30), 2.3f, SpriteEffects.None, 1);
            spriteBatch.Draw(clouds2, new Vector2(clouds2Pos, 0), null, Color.White, 0f, new Vector2(20, 30), 2.3f, SpriteEffects.None, 0);
            spriteBatch.Draw(clouds3, new Vector2(clouds3Pos, 0), null, Color.White, 0f, new Vector2(20, 30), 2.3f, SpriteEffects.None, 0);
        }
    }
}
