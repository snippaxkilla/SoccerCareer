using SoccerCareer.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SoccerCareer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SoccerCareer : GameEnvironment
    {
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(1920, 1080);
            ApplyResolutionSettings();

            // TODO: use this.Content to load your game content here
            GameStateManager.AddGameState("PlayingState", new PlayingState());
            GameStateManager.SwitchTo("PlayingState");
        }
        
    }
}
