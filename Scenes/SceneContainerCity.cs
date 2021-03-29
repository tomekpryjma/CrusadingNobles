using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrusadingNobles
{
    public class SceneContainerCity : SceneContainer
    {
        public SceneContainerCity(Game1 game, string backgroundImageName, string currentSceneName, string titleOfScene) : base(game, backgroundImageName, currentSceneName, titleOfScene)
        {
            _game = game;
            sceneComponents = new List<GameComponent>();
        }

        public override void Initialize()
        {
            sceneComponents.Add(new EnterArea(_game, "gameplayScene", 0, 0, "menuScene", _game.gameSceneManager, 60, 60));
            AddSceneComponents(sceneComponents);
            base.Initialize();
        }
    }
}
