using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerCareer.GameObjects
{
    class LeftGoal : SpriteGameObject
    {
        public int adjustment = 50;
        public LeftGoal() : base ("GoalLeft")
        {
            origin = Center;
            scale = 0.2f;
            position.X = adjustment;
            position.Y = GameEnvironment.Screen.Y / 2;
        }
    }
}
