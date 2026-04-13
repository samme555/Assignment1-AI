using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_AI
{
    public class ChargeState : FSMAgentState
    {
        private const float ChargeRange = 250f;
        private const float ChaseRange = 500f;
        private const float ChargeSpeedMultiplier = 2f;

        public ChargeState(FSMAgent agent) : base(agent) { }

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float distance = agent.DistanceToPlayer();

            if (distance >= ChaseRange)
            {
                agent.ChangeState(new MergeState(agent));
                return;
            }

            if (distance >= ChargeRange)
            {
                agent.ChangeState(new ChaseState(agent));
                return;
            }

            float chargeSpeed = agent.GetSpeed() * ChargeSpeedMultiplier;
            agent.MoveTowards(agent.GetPlayer().GetPosition(), chargeSpeed, dt);
        }
    }
}
