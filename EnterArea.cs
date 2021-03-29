using System;
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
        private SpriteFont _font;
        private MouseState _mouseState;

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

        protected override void LoadContent()
        {
            _font = _game.Content.Load<SpriteFont>("Fonts/Main");
        }

        public override void Update(GameTime gameTime)
        {
            _mouseState = Mouse.GetState();
            if (MouseIsInBounds(_mouseState.X, _mouseState.Y))
            {
                Mouse.SetCursor(MouseCursor.Hand);
                if (_mouseState.LeftButton == ButtonState.Pressed)
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


            if (MouseIsInBounds(_mouseState.X, _mouseState.Y)) {
                ShowTooltip(_game.gameSceneManager.GetGameScene(_gameSceneToChangeTo).GetSceneContainer().sceneTitle, _mouseState.X, _mouseState.Y);
            }

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

        private void ShowTooltip(string text, int x, int y)
        {
            _game.GetSpriteBatch().DrawString(_font, text, new Vector2((x + 15), (y + 15)), Color.Cyan);
        }
    }
}
