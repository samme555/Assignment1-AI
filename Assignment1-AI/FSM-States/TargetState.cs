using Microsoft.Xna.Framework;

namespace Assignment1_AI
{
    public class TargetState : FSMAgentState
    {
        public TargetState(FSMAgent agent) : base(agent) { }

        public override void Enter()
        {
            //for debug
        }

        public override void Update(GameTime gameTime)
        {
            float distance = Vector2.Distance(
                agent.GetPosition(),
                agent.GetPlayer().GetPosition()
                );

            if (distance < 250f)
            {
                agent.ChangeState(new ChaseState(agent));
            }
        }

        public override void Exit()
        {
            //for debug
        }
    }
}
