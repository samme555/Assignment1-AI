using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Assignment1_AI
{
    public class Player
    {
        private Vector2 pos = new Vector2(400, 300);
        private float speed = 300f;
        private Texture2D pixel;

        private float range = 400f;
        private float cooldown = 0.5f;
        private float timer = 0f;
        private int damage = 1;

        public Player(Texture2D pixelTexture)
        {
            pixel = pixelTexture;
            pos = new Vector2(400, 300);
        }


        public void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            Vector2 movement = Vector2.Zero;

            if (keyboard.IsKeyDown(Keys.W))
                movement.Y -= 1;
            if (keyboard.IsKeyDown(Keys.S))
                movement.Y += 1;
            if (keyboard.IsKeyDown(Keys.A))
                movement.X -= 1;
            if (keyboard.IsKeyDown(Keys.D))
                movement.X += 1;
           

            if (movement != Vector2.Zero)
                movement.Normalize();

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            pos += movement * speed * dt;
            timer += dt;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pixel, new Rectangle((int)pos.X, (int)pos.Y, 40, 40), Color.White);
        }

        public Vector2 GetPosition()
        {
            return pos;
        }

        public Bullet AttackNearestEnemy(List<Enemy> enemies)
        {
            if (timer < cooldown)
                return null;

            Enemy closest = null;
            float closestDist = float.MaxValue;

            foreach (var enemy in enemies)
            {
                float dist = Vector2.Distance(pos, enemy.GetPosition());

                if (dist < closestDist && dist <= range) 
                {
                    closestDist = dist;
                    closest = enemy;
                }
            }

            if (closest != null)
            {
                timer = 0f;
                return new Bullet(pixel, pos, closest.GetPosition(), damage);
            }

            return null;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, 40, 40);
        }
    }
}
