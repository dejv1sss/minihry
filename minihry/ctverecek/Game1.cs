using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ctverecek
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private float r = 0.5f;
        private float g = 0.5f;
        private float b = 0.5f;
        private float brightness = 1.0f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Vypíšeme ovládání do konzole
            Console.WriteLine("🎨 Ovládání RGB a jasu:");
            Console.WriteLine("R / T - Zvýšit / snížit červenou");
            Console.WriteLine("G / H - Zvýšit / snížit zelenou");
            Console.WriteLine("B / N - Zvýšit / snížit modrou");
            Console.WriteLine("Šipka nahoru / dolů - Zvýšit / snížit jas");
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            float speed = 0.5f * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // --- RGB ovládání ---
            if (keyState.IsKeyDown(Keys.R))
                r += speed;
            if (keyState.IsKeyDown(Keys.T))
                r -= speed;

            if (keyState.IsKeyDown(Keys.G))
                g += speed;
            if (keyState.IsKeyDown(Keys.H))
                g -= speed;

            if (keyState.IsKeyDown(Keys.B))
                b += speed;
            if (keyState.IsKeyDown(Keys.N))
                b -= speed;

            // --- Jas ---
            if (keyState.IsKeyDown(Keys.Up))
                brightness += speed;
            if (keyState.IsKeyDown(Keys.Down))
                brightness -= speed;

            // Omez hodnoty do rozsahu 0–1 (nebo 2 u jasu)
            r = MathHelper.Clamp(r, 0f, 1f);
            g = MathHelper.Clamp(g, 0f, 1f);
            b = MathHelper.Clamp(b, 0f, 1f);
            brightness = MathHelper.Clamp(brightness, 0f, 2f);

            // Vypisuj aktuální barvu do konzole
            Console.Title = $"R={r:F2} G={g:F2} B={b:F2} | Jas={brightness:F2}";

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Spočítej barvu s jasem
            Color bgColor = new Color(r * brightness, g * brightness, b * brightness);
            GraphicsDevice.Clear(bgColor);

            _spriteBatch.Begin();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
