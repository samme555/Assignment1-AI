using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

namespace Assignment1_AI
{
    public abstract class Enemy
    {
        protected Texture2D pixel;
        protected Vector2 position;
        protected float speed;
        protected Color color;

        public Enemy(Texture2D pixel, Vector2 startpos, float speed, Color color)
        {
            this.pixel = pixel;
            this.position = startpos;
            this.speed = speed;
            this.color = color;
        }

        public abstract void Update(GameTime gameTime, Player player);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, 20, 20), Color.White);
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
    }
}
