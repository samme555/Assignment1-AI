using Microsoft.Xna.Framework;

namespace Assignment1_AI
{
    public class ChaseState : FSMAgentState
    {
        private const float ChargeRange = 250f;
        private const float ChaseRange = 500f;

        public ChaseState(FSMAgent agent) : base(agent) { }

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float distance = agent.DistanceToPlayer();

            if (distance < ChargeRange)
            {
                agent.ChangeState(new ChargeState(agent));
                return;
            }

            if (distance >= ChaseRange)
            {
                agent.ChangeState(new MergeState(agent));
                return;
            }

            agent.MoveTowards(agent.GetPlayer().GetPosition(), agent.GetSpeed(), dt);
        }
    }
}
