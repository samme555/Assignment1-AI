using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Assignment1_AI
{
    public class FSMAgent : Enemy
    {
        public FSMAgent(Texture2D pixel, Vector2 startPos)
            : base(pixel, startPos, 100f, Color.Red)
        {
        }

        public override void Update(GameTime gameTime, Player player)
        {
            Vector2 direction = player.GetPosition() - position;

            if (direction != Vector2.Zero)
                direction.Normalize();

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += direction * speed * dt;
        }
    }
}
