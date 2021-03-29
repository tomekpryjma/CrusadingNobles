using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrusadingNobles
{
    public class SceneContainer : DrawableGameComponent
    {
        protected Game1 _game;
        protected Texture2D _background;
        protected Rectangle _backgroundContainer;
        protected string _backgroundImageName;
        public string sceneName { get; }
        public string sceneTitle { get; }
        public List<GameComponent> sceneComponents { get; set; }

        public SceneContainer(Game1 game, string backgroundImageName, string sceneMachineName, string titleOfScene) : base(game)
        {
            _game = game;
            _backgroundImageName = backgroundImageName;
            sceneName = sceneMachineName;
            sceneTitle = titleOfScene;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _background = _game.Content.Load<Texture2D>(_backgroundImageName);
            _backgroundContainer = new Rectangle(0, 0, _game.Window.ClientBounds.Width, _game.Window.ClientBounds.Height);
        }

        public override void Draw(GameTime gameTime)
        {
            _game.GetSpriteBatch().Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            _game.GetSpriteBatch().Draw(_background, new Vector2(0, 0), _backgroundContainer, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            _game.GetSpriteBatch().End();
            base.Draw(gameTime);
        }

        protected void AddSceneComponents(List<GameComponent> sceneComponents)
        {
            foreach (GameComponent component in sceneComponents)
            {
                if (!_game.Components.Contains(component))
                {
                    _game.Components.Add(component);
                }
            }
        }
    }
}
