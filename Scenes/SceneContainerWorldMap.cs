using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrusadingNobles
{
    public class SceneContainerWorldMap : SceneContainer
    {
        public SceneContainerWorldMap(Game1 game, string backgroundImageName, string currentSceneName, string titleOfScene) : base(game, backgroundImageName, currentSceneName, titleOfScene)
        {
            _game = game;
            sceneComponents = new List<GameComponent>();
        }

        public override void Initialize()
        {
            sceneComponents.Add(new EnterArea(_game, "menuScene", 630, 480, "gameplayScene", _game.gameSceneManager, 60, 60));
            AddSceneComponents(sceneComponents);
            base.Initialize();
        }
    }
}
