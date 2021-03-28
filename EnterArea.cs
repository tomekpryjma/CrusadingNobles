﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrusadingNobles
{
    public class EnterArea : DrawableGameComponent
    {
        public string currentGameScene;
        private Game1 _game;
        private int _width;
        private int _height;
        private int _x;
        private int _y;
        private string _gameSceneToChangeTo;
        private GameSceneManager _gameSceneManager;
        private Texture2D _background;
        private Vector2 _coords;
        private Color[] _bgColour;

        public EnterArea(Game1 game, string currGameScene, int x, int y, string gameSceneToChangeTo, GameSceneManager gameSceneManager) : base(game)
        {
            _game = game;
            currentGameScene = currGameScene;
            _x = x;
            _y = y;
            _gameSceneToChangeTo = gameSceneToChangeTo;
            _gameSceneManager = gameSceneManager;
            _width = 60;
            _height = 30;
        }
        public EnterArea(Game1 game, string currGameScene, int x, int y, string gameSceneToChangeTo, GameSceneManager gameSceneManager, int width, int height) : base(game)
        {
            _game = game;
            currentGameScene = currGameScene;
            _x = x;
            _y = y;
            _gameSceneToChangeTo = gameSceneToChangeTo;
            _gameSceneManager = gameSceneManager;
            _width = width;
            _height = height;
        }

        public override void Initialize()
        {
            _background = new Texture2D(_game.GraphicsDevice, _width, _height);
            _coords = new Vector2(_x, _y);
            //SetBackgroundColour(Color.Red);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            if (MouseIsInBounds(mouseState.X, mouseState.Y))
            {
                Mouse.SetCursor(MouseCursor.Hand);
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    _gameSceneManager.SwitchScene(_gameSceneToChangeTo);
                    return;
                }
            }
            else
            {
                Mouse.SetCursor(MouseCursor.Arrow);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _game.GetSpriteBatch().Begin();
            _game.GetSpriteBatch().Draw(_background, _coords, Color.White);
            _game.GetSpriteBatch().End();
            base.Draw(gameTime);
        }

        private bool MouseIsInBounds(int mouseX, int mouseY)
        {
            if (
                (mouseX > _x && mouseX < _x + _width) &&
                (mouseY > _y && mouseY < _y + _height)
            )
            {
                return true;
            }
            return false;
        }

        private void SetBackgroundColour(Color colour)
        {
            _bgColour = new Color[_width * _height];

            for (int i = 0; i < _bgColour.Length; ++i)
            {
                _bgColour[i] = colour;
            }

            _background.SetData(_bgColour);
        }
    }
}
