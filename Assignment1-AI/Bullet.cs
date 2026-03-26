using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment1_AI
{
    public class Bullet
    {
        private Texture2D pixel;
        private Vector2 position;
        private Vector2 direction;
        private float speed;
        private int size;
        private bool active;
        public int damage;

        public Bullet(Texture2D pixel, Vector2 startPosition, Vector2 targetPosition, int damage)
        {
            this.pixel = pixel;
            this.position = startPosition;
            this.damage = damage;

            speed = 400f;
            size = 10;
            active = true;

            direction = targetPosition - startPosition;

            if (direction != Vector2.Zero)
                direction.Normalize();
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += direction * speed * dt;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!active)
                return;

            spriteBatch.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, size, size), Color.Yellow);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, size, size);
        }

        public bool IsActive()
        {
            return active;
        }

        public void Deactivate()
        {
            active = false;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
        
        public int GetDamage()
        {
            return damage = 1;
        }
    }

}
