using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment1_AI
{
    public abstract class Enemy
    {
        protected Texture2D pixel;
        protected Vector2 position;
        protected float speed;
        protected Color color;
        protected bool markedForRemoval = false;

        protected int health;
        protected int maxHealth;
        protected int size = 20;

        public Enemy(Texture2D pixel, Vector2 startpos, float speed, Color color)
        {
            this.pixel = pixel;
            this.position = startpos;
            this.speed = speed;
            this.color = color;

            maxHealth = 1;
            health = maxHealth;
        }

        public abstract void Update(GameTime gameTime, Player player);

        public abstract void Draw(SpriteBatch spriteBatch);

        public void MarkForRemoval()
        {
            markedForRemoval = true;
        }

        public bool IsMarkedForRemoval()
        {
            return markedForRemoval;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2 newPos)
        {
            position = newPos;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(float newSpeed)
        {
            speed = newSpeed;
        }

        public int GetHealth()
        {
            return health;
        }
        public void SetHealth(int newHealth)
        {
            health = newHealth;
            if (health > maxHealth)
                maxHealth = health;
        }

        public void AddHealth(int amount)
        {
            health += amount;
            if (health > maxHealth)
                maxHealth = health;
        }

        public int GetSize()
        {
            return size;
        }

        public void IncreaseSize(int amount)
        {
            size += amount;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
        }

        public bool IsDead()
        {
            return health <= 0;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, size, size);
        }

    }
}
