using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace animation_lesson
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tribblebrownTexture, tribblegreyTexture, tribblecreamTexture, fur4Texture;

        SoundEffect tribbleSound;
        

        Rectangle window;

        Rectangle tribbleBrownRect;
        Vector2 tribblebrownSpeed;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            tribbleBrownRect = new Rectangle(301, 10, 100, 100);
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth =window.Width;
            _graphics.PreferredBackBufferHeight =window.Height;
            _graphics.ApplyChanges();

            tribblebrownSpeed = new Vector2(2,2);
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            tribblebrownTexture = Content.Load<Texture2D>("tribblebrown");
            tribbleSound = Content.Load<SoundEffect>("tribble_coo");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            tribbleBrownRect.X += (int)tribblebrownSpeed.X;
            if (tribbleBrownRect.Right > window.Width || tribbleBrownRect.Left <=0)
            {
                tribblebrownSpeed.X *= -1;
                tribbleSound.Play();
                
            }
            tribbleBrownRect.Y += (int)tribblebrownSpeed.Y;

            if (tribbleBrownRect.Bottom > window.Height || tribbleBrownRect.Top < 0)
            {
                tribblebrownSpeed.Y *= -1;
                tribbleSound.Play();

            }






            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            _spriteBatch.Draw(tribblebrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
