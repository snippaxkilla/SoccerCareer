using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerCareer.GameObjects
{
    class Keeper : SpriteGameObject
    {
        public float speed = 20;

        public Keeper() : base("Player")
        {
            //player needs to weigh more then a ball
            mass = 2f;
            scale = 0.5f;
            Mirror = true;
            origin = Center;
            position.X = 200;
            position.Y = GameEnvironment.Screen.Y / 2;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyDown(Keys.A))
            {
                velocity.X -= speed;
                Mirror = false;
            }
            if (inputHelper.IsKeyDown(Keys.D))
            {
                velocity.X += speed;
                Mirror = true;
            }
            if (inputHelper.IsKeyDown(Keys.W))
            {
                velocity.Y -= speed;
            }
            if (inputHelper.IsKeyDown(Keys.S))
            {
                velocity.Y += speed;
            }
            base.HandleInput(inputHelper);
        }

        public override void Update(GameTime gameTime)
        {
            // drag
            velocity *= 0.95f;
            base.Update(gameTime);

            //don't let the players leave we want them to bounce back
            if ((position.X > GameEnvironment.Screen.X || ((position.Y > GameEnvironment.Screen.Y))))
                velocity *= -speed/4;

            if ((position.X < 0 || ((position.Y < 0))))
                velocity *= -speed / 4;
        }

        public override void Reset()
        {
            position.X = 200;
            position.Y = GameEnvironment.Screen.Y / 2;
            base.Reset();
        }
    }
}
