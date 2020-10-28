using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerCareer.GameObjects
{
    class RightGoal : SpriteGameObject
    {
       
        public int adjustment = 50;
        public RightGoal() : base("GoalRight")
        {
            origin = Center;
            scale = 0.2f;
            position.X = GameEnvironment.Screen.X - adjustment;
            position.Y = GameEnvironment.Screen.Y / 2 ;
        }
    }
}
