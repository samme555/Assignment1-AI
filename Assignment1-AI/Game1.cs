using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Assignment1_AI
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Player player;
        public Texture2D pixel;

        public List<Enemy> enemies = new List<Enemy>();
        private Random random = new Random();

        private float spawnTimer = 0f;
        private float spawnInterval = 2f;
        private int maxEnemies = 10;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });

            player = new Player(pixel);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            spawnTimer += dt;

            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }

            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime, player);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            player.Draw(spriteBatch);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SpawnEnemy()
        {
            if (enemies.Count >= maxEnemies)
                return;

            Vector2 spawnPosition = Vector2.Zero;

            int side = random.Next(4);

            switch (side)
            {
                case 0: //top
                    spawnPosition = new Vector2(random.Next(0, 800), -40);
                    break;
                case 1: //bottom
                    spawnPosition = new Vector2(random.Next(0, 800), 600);
                    break;
                case 2: //left
                    spawnPosition = new Vector2(-40, random.Next(0, 600));
                    break;
                case 3: //right
                    spawnPosition = new Vector2(800, random.Next(0, 600));
                    break;
            }

            bool spawnFSM = random.Next(2) == 0;

            if (spawnFSM)
                enemies.Add(new FSMAgent(pixel, spawnPosition));
            else
                enemies.Add(new DTAgent(pixel, spawnPosition));
        }
    }
}
