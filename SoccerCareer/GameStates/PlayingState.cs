using SoccerCareer.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerCareer.GameStates
{
    class PlayingState : GameObjectList
    {
        Player player;
        Keeper keeper;
        Ball ball;
        LeftGoal leftGoal;
        RightGoal rightGoal;
        GameObjectList balls;

        public PlayingState()
            :base()
        {
            this.Add(new SpriteGameObject("SoccerfieldBackground"));

            //more balls is more fun
            balls = new GameObjectList();
            this.Add(balls);

            player = new Player();
            keeper = new Keeper();
            ball = new Ball();
            leftGoal = new LeftGoal();
            rightGoal = new RightGoal();
            Add(ball);
            Add(keeper);
            Add(player);
            Add(leftGoal);
            Add(rightGoal);
            
        }

        public void ElasticCollision(GameObject firstBall, GameObject secondBall)
        {
            float newVelX1 = (firstBall.Velocity.X * (firstBall.Mass - secondBall.Mass) +(2 * secondBall.Mass * secondBall.Velocity.X)) / (firstBall.Mass + secondBall.Mass);
            float newVelY1 = (firstBall.Velocity.Y * (firstBall.Mass - secondBall.Mass) +(2 * secondBall.Mass * secondBall.Velocity.Y)) / (firstBall.Mass + secondBall.Mass);
            float newVelX2 = (secondBall.Velocity.X * (secondBall.Mass - firstBall.Mass) +(2 * firstBall.Mass * firstBall.Velocity.X)) / (firstBall.Mass + secondBall.Mass);
            float newVelY2 = (secondBall.Velocity.Y * (secondBall.Mass - firstBall.Mass) +(2 * firstBall.Mass * firstBall.Velocity.Y)) / (firstBall.Mass + secondBall.Mass);

            firstBall.Velocity = new Vector2(newVelX1, newVelY1);
            secondBall.Velocity = new Vector2(newVelX2, newVelY2);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
           
            base.HandleInput(inputHelper);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Ball ball in balls.Children)
            {
                //left goal
                if (Vector2.Distance(leftGoal.Position, ball.Position) < (leftGoal.Sprite.Width * leftGoal.Scale) / 2 + (ball.Sprite.Width * ball.Scale) / 2)
                {
                    ball.Reset();
                    player.Reset();
                    keeper.Reset();
                    //ScoreCount.ScorePlayer1 += 100;

                }

                //right goal
                if (Vector2.Distance(rightGoal.Position, ball.Position) < (rightGoal.Sprite.Width * rightGoal.Scale) / 2 + (ball.Sprite.Width * ball.Scale) / 2)
                {
                    ball.Reset();
                    player.Reset();
                    keeper.Reset();
                   
                }
            }

            //player
            if (Vector2.Distance(player.Position, ball.Position) < (player.Sprite.Width * player.Scale) / 2 + (ball.Sprite.Width * ball.Scale) / 2)
            {
                ElasticCollision(player, ball);
            }

            //keeper
            if (Vector2.Distance(keeper.Position, ball.Position) < (keeper.Sprite.Width * keeper.Scale) / 2 + (ball.Sprite.Width * ball.Scale) / 2)
            {
                ElasticCollision(keeper, ball);
            }

            base.Update(gameTime);

            //if (GameEnvironment.KeyboardState.IsKeyDown(Keys.Space))
             //   GameEnvironment.SwitchTo(1);
        }
    }
}
