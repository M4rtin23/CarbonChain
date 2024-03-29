﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Carbons.Converter;

namespace Carbons{
    public class Game1 : Game{
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Objects.
        static string g = "3,4-Di Metil-2,3-Di Etil-Heptano";
//        private Chain chain = new Chain(5, new int[]{3,2,2,2,3,2});
        private Chain chain = new Chain(ChainToMachine(g), BranchesToMachine(g), TypeOfChain(g));

        public static SpriteFont Font0, Font1, Font2;
        public Game1(){
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize(){
            Font0 = Content.Load<SpriteFont>("Font0");
			Font1 = Content.Load<SpriteFont>("Font1");
            Font2 = Content.Load<SpriteFont>("Font2");
            base.Initialize();
        }

        protected override void LoadContent(){
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime){
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime){
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            chain.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
