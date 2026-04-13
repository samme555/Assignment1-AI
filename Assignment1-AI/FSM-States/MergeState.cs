using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_AI
{
    public class MergeState : FSMAgentState
    {
        private const float ChargeRange = 250f;
        private const float ChaseRange = 500f;
        private const float mergeMoveSpeed = 100f;
        private const int SizeIncreasePerMerge = 10;

        public MergeState(FSMAgent agent) : base(agent) { }

        public override void Update(GameTime gameTime)
        {
            float distanceToPlayer = agent.DistanceToPlayer();

            if (distanceToPlayer < ChargeRange)
            {
                agent.ChangeState(new ChargeState(agent));
                return;
            }

            if (distanceToPlayer < ChaseRange)
            {
                agent.ChangeState(new ChaseState(agent));
                return;
            }

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            FSMAgent partner = FindNearestMergePartner();

            if (partner == null)
                return;

            agent.MoveTowards(partner.GetPosition(), mergeMoveSpeed, dt);

            if (agent.GetBounds().Intersects(partner.GetBounds()))
            {
                MergeWith(partner);
            }
        }

        private FSMAgent FindNearestMergePartner()
        {
            List<Enemy> allEnemies = agent.GetAllEnemies();

            FSMAgent closest = null;
            float closestDistance = float.MaxValue;

            foreach (Enemy enemy in allEnemies)
            {
                if (enemy == agent)
                    continue;

                if (enemy.IsMarkedForRemoval())
                    continue;

                if (enemy is FSMAgent otherAgent)
                {
                    if (!otherAgent.IsInMergeState())
                        continue;

                    float distance = Vector2.Distance(agent.GetPosition(), otherAgent.GetPosition());
                
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closest = otherAgent;
                    }                
                }
            }

            return closest;
        }

        private void MergeWith(FSMAgent partner)
        {
            if (partner.IsMarkedForRemoval() || agent.IsMarkedForRemoval())
                return;

            if (agent.GetHashCode() > partner.GetHashCode())
                return;

            agent.AddHealth(partner.GetHealth());
            agent.IncreaseSize(SizeIncreasePerMerge);

            partner.MarkForRemoval();
        }
    }
}
