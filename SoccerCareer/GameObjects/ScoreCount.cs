using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerCareer.GameObjects
{
    public class ScoreCount
    {
        public int ScorePlayer1;
        public int ScorePlayer2;

        private SpriteFont _font;

        public ScoreCount(SpriteFont font)
        {
            _font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, ScorePlayer1.ToString(), new Vector2(100, GameEnvironment.Screen.Y - 100), (Color.White));
            spriteBatch.DrawString(_font, ScorePlayer2.ToString(), new Vector2(GameEnvironment.Screen.X - 100, GameEnvironment.Screen.Y - 100), (Color.White));
        }

        public void PointsP1()
        {
            ScorePlayer1 += 100;
        }

        public void PointsP2()
        {
            ScorePlayer2 += 100;
        }
    }
}
