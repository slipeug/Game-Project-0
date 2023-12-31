﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;


namespace TitleScreen
{
    public class MainMenu
    {
        private const string INSTRUCTIONS_TEXT = "Press ESC or BACK button to leave the game";
        private const string GAME_TITLE_1 = "Cursed";
        private const string GAME_TITLE_2 = "Island";
        private const int SHADOW_PX = 2;
        private const int BIG_SHADOW_PX = 5;

        private SpriteFont _instructions;
        private SpriteFont _gameName1;
        private SpriteFont _gameName2;



        public void LoadContent(ContentManager content)
        {
            _gameName1 = content.Load<SpriteFont>("SamuraiBlastBig");
            _gameName2 = content.Load<SpriteFont>("SamuraiBlast");
            _instructions = content.Load<SpriteFont>("Cownaffle");

        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            #region Title

            Vector2 textSize1 = _gameName1.MeasureString(GAME_TITLE_1);
            Vector2 textSize2 = _gameName2.MeasureString(GAME_TITLE_2);

            // Calculate the position to center the text on the screen
            float positionX1 = (GlobalVariables.WINDOW_WIDTH - textSize1.X) / 2;
            float positionX2 = (GlobalVariables.WINDOW_WIDTH - textSize2.X) / 2;
            float positionY1 = (GlobalVariables.WINDOW_HEIGHT - textSize1.Y) / 4 * 1;
            float positionY2 = (GlobalVariables.WINDOW_HEIGHT - textSize2.Y) / 10 * 6;

            // game name shadow
            spriteBatch.DrawString(_gameName1, GAME_TITLE_1, new Vector2(positionX1, positionY1 + BIG_SHADOW_PX), Color.Black);
            spriteBatch.DrawString(_gameName2, GAME_TITLE_2, new Vector2(positionX2, positionY2 + BIG_SHADOW_PX), Color.Black);
            // game name 
            spriteBatch.DrawString(_gameName1, GAME_TITLE_1, new Vector2(positionX1, positionY1), Color.DeepSkyBlue);
            spriteBatch.DrawString(_gameName2, GAME_TITLE_2, new Vector2(positionX2, positionY2), Color.SandyBrown);

            #endregion


            #region Instructions

            Vector2 textSize = _instructions.MeasureString(INSTRUCTIONS_TEXT);

            // Calculate the position to center the text on the screen
            float positionX = (GlobalVariables.WINDOW_WIDTH - textSize.X) / 2;
            float positionY = (GlobalVariables.WINDOW_HEIGHT - textSize.Y) / 8 * 7;

            float transparancy = 2 * (float)Math.Cos(gameTime.TotalGameTime.TotalSeconds * 5) + 2;
            // instructions shadow
            spriteBatch.DrawString(
                _instructions, 
                INSTRUCTIONS_TEXT, 
                new Vector2(positionX + SHADOW_PX, positionY + SHADOW_PX), 
                Color.Black * transparancy
            );
            // instructions
            spriteBatch.DrawString(
                _instructions, 
                INSTRUCTIONS_TEXT, 
                new Vector2(positionX, positionY), 
                Color.White * transparancy
            );


            #endregion
        }
    }
}
