using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace Assignment1_AI
{
    public class FSMAgent : Enemy
    {
        private FSMAgentState currentState;
        private Player player;
        private List<Enemy> allEnemies;

        public FSMAgent(Texture2D pixel, Vector2 startPos, Player player, List<Enemy> allEnemies) : base(pixel, startPos, 100f, Color.Blue)
        {
            this.player = player;
            this.allEnemies = allEnemies;
            ChangeState(new ChaseState(this));
        }

        public override void Update(GameTime gameTime, Player player)
        {
            currentState.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, size, size), Color.Blue);
        }

        public void ChangeState(FSMAgentState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }

        public List<Enemy> GetAllEnemies()
        {
            return allEnemies;
        }

        public bool IsInMergeState()
        {
            return currentState is MergeState;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public void MoveTowards(Vector2 targetPos, float moveSpeed, float dt)
        {
            Vector2 direction = targetPos - position;

            if (direction != Vector2.Zero)
                direction.Normalize();

            position += direction * moveSpeed * dt;
        }

        public float DistanceToPlayer()
        {
            return Vector2.Distance(position, player.GetPosition());
        }
    }
}
