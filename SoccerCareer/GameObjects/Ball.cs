using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerCareer.GameObjects
{
    class Ball : SpriteGameObject
    {
        public Ball() : base ("Ball")
        {
            origin = Center;
            scale = 0.3f;
            position.X = GameEnvironment.Screen.X / 2; // horizontal center on screen
            position.Y = GameEnvironment.Screen.Y / 2; // bottom of screen 
        }
        public override void Update(GameTime gameTime)
        {
            // drag
            velocity *= 0.995f;
            base.Update(gameTime);

            if (position.X > GameEnvironment.Screen.X || (position.Y > GameEnvironment.Screen.Y))
            {
                velocity = -velocity;
            }

            if (position.X < 0 || (position.Y < 0))
            {
                velocity = -velocity;
            }

        }

        //reset the ball to it's middle position after there has been scored
        public override void Reset()
        {
            position.X = GameEnvironment.Screen.X / 2;
            position.Y = GameEnvironment.Screen.Y / 2;
            velocity.X = 0;
            velocity.Y = 0;
            base.Reset();
        }
    }
}
