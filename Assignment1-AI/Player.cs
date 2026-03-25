using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Assignment1_AI
{
    public class Player
    {
        private Vector2 pos = new Vector2(400, 300);
        private float speed = 300f;
        private Texture2D pixel;

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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pixel, new Rectangle((int)pos.X, (int)pos.Y, 40, 40), Color.White);
        }

        public Vector2 GetPosition()
        {
            return pos;
        }
    }
}
