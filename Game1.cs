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
        Rectangle tribbleGreyRect;

        Vector2 tribblebrownSpeed;
        Vector2 tribblegreySpeed;


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
            tribbleGreyRect = new Rectangle(400, 12, 100, 100);

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth =window.Width;
            _graphics.PreferredBackBufferHeight =window.Height;
            _graphics.ApplyChanges();

            tribblebrownSpeed = new Vector2(2,2);
            tribblegreySpeed = new Vector2(4, 2);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            tribblebrownTexture = Content.Load<Texture2D>("tribblebrown");
            tribblegreyTexture = Content.Load<Texture2D>("tribblegrey");
            tribblecreamTexture = Content.Load<Texture2D>("tribblecream");
            fur4Texture = Content.Load<Texture2D>("fur4");


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

           
            
            tribbleGreyRect.Y += (int)tribblegreySpeed.Y;
            if (tribbleGreyRect.Bottom > window.Height || tribbleGreyRect.Top < 0)
            {
                tribblegreySpeed.Y *= -1;
                GraphicsDevice.Clear(Color.Red);    
            }






            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            _spriteBatch.Draw(tribblebrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.Draw(tribblegreyTexture, tribbleGreyRect, Color.White);



            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
