using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Assignment1_AI
{
    public class FSMAgent : Enemy
    {
        private FSMAgentState currentState;
        private Player player;
        public FSMAgent(Texture2D pixel, Vector2 startPos, Player player)
            : base(pixel, startPos, 100f, Color.Red)
        {
            this.player = player;
            ChangeState(new TargetState(this));
        }

        public override void Update(GameTime gameTime, Player player)
        {
            if (currentState != null)
            {
                currentState.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, 20, 20), Color.Blue);
        }

        public void ChangeState(FSMAgentState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            currentState = newState;

            if (currentState != null)
            {
                currentState.Enter();
            }
        }

        public Player GetPlayer()
        {
            return player;
        }
    }
}
