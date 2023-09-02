using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TitleScreen
{
    public class Gem : AnimatedSprite
    {
        public void LoadContent(ContentManager content)
        {
            base.position = new Vector2(320, 170);
            base.LoadContent(content, "icons8-sparkling-diamond", 0.03f);
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
