using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Assignment1_AI
{
    public class DTAgent : Enemy
    {
        public DTAgent(Texture2D pixel, Vector2 startPos, Player player)
            : base(pixel, startPos, 80f, Color.Blue)
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, 20, 20), Color.Red);
        }
    }
}
