using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace RPSsimulation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Random rnd;

        Texture2D RockSprite;
        Texture2D ScissorsSprite;
        Texture2D PaperSprite;
        // all the gamepeices 
        public static List<GamePiece> GamePieces = new List<GamePiece>();

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // create a new random
            rnd = new Random();
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // load all sprites
            RockSprite = Content.Load<Texture2D>("Rock");
            ScissorsSprite = Content.Load<Texture2D>("Scissors");
            PaperSprite = Content.Load<Texture2D>("Paper");

            // create gamepeices
            CreateGamepieces(100);

        }

        protected override void Update(GameTime gameTime)
        {   
            // exit if we press esc
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // update all the gamepieces
            foreach (GamePiece i in GamePieces)
            {
                i.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // clear screen
            GraphicsDevice.Clear(Color.White);
            // start drawing
            _spriteBatch.Begin();            
            // draw the gamepieces
            foreach (GamePiece i in GamePieces)
            {
                i.Draw(_spriteBatch);
            }
            // stop drawing
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        // function for creating gamepieces
        public void CreateGamepieces(int amount)
        {
            // create amount rocks, paper, and sissors
            for (int i = 0; i < amount; i++)
            {
                GamePieces.Add(new GamePiece(new Vector2(rnd.Next(0, 800), rnd.Next(0, 400)), RockSprite, ScissorsSprite, PaperSprite));
                GamePieces.Add(new GamePiece(new Vector2(rnd.Next(0, 800), rnd.Next(0, 400)), PaperSprite, RockSprite, ScissorsSprite));
                GamePieces.Add(new GamePiece(new Vector2(rnd.Next(0, 800), rnd.Next(0, 400)), ScissorsSprite, PaperSprite, RockSprite));
            }
            
        }
        
    }    
}
