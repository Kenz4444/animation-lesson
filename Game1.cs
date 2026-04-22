using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        Rectangle tribbleCreamRect;
        Rectangle fur4Rect;

        Color backColor, brownColorMask;


        Vector2 tribblebrownSpeed;
        Vector2 tribblegreySpeed;
        Vector2 tribblecreamSpeed;
        Vector2 fur4Speed;


        int randNum;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Random generator = new Random();
            brownColorMask = Color.White;
            
            randNum = generator.Next(1, 4);

            if(randNum == 1)
            {
                fur4Rect = new Rectangle(400, 10, 100, 100);
            }
            else if(randNum == 2)
            {
                fur4Rect = new Rectangle(400, 10, 200, 50);
            }
            else if (randNum == 3)
            {
                fur4Rect = new Rectangle(400, 10, 20, 40);
            }


            tribbleBrownRect = new Rectangle(301, 10, 100, 100);
            tribbleGreyRect = new Rectangle(400, 12, 100, 100);
            tribbleCreamRect = new Rectangle(400, 12, 100, 100);
            

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth =window.Width;
            _graphics.PreferredBackBufferHeight =window.Height;
            _graphics.ApplyChanges();

            tribblebrownSpeed = new Vector2(1,2);
            tribblegreySpeed = new Vector2(4, 7);
            tribblecreamSpeed = new Vector2(6, 2);
            fur4Speed = new Vector2(2, 2);


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
                backColor = Color.Orange;
                

            }
            tribbleBrownRect.Y += (int)tribblebrownSpeed.Y;

            if (tribbleBrownRect.Bottom > window.Height || tribbleBrownRect.Top < 0)
            {
                tribblebrownSpeed.Y *= -1;
                tribbleSound.Play();
                backColor = Color.White;

            }



            tribbleGreyRect.Y += (int)tribblegreySpeed.Y;

            if (tribbleGreyRect.Top > window.Height)  
            {
                
                tribbleGreyRect.Y = -tribbleGreyRect.Height;
                
                
                
            }
            
                




                tribbleCreamRect.X += (int)tribblecreamSpeed.X;
            if (tribbleCreamRect.Right > window.Width || tribbleCreamRect.Left <= 0)
            {
                tribblecreamSpeed.X *= -1;
                tribbleSound.Play();
                backColor = Color.Pink;

            }




            fur4Rect.X += (int)fur4Speed.X;
            if (fur4Rect.Right > window.Width || fur4Rect.Left <= 0)
            {
                fur4Speed.X *= -1;
                
                


            }

            fur4Rect.Y += (int)fur4Speed.Y;

            if (fur4Rect.Bottom > window.Height || fur4Rect.Top < 0)
            {
                fur4Speed.Y *= -1;
                
                

            }

            






            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backColor);

            _spriteBatch.Begin();


            _spriteBatch.Draw(tribblebrownTexture, tribbleBrownRect, brownColorMask);
            _spriteBatch.Draw(tribblegreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribblecreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(fur4Texture, fur4Rect, Color.White);











            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
