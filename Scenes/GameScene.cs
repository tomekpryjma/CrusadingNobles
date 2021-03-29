using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrusadingNobles
{
    public class GameScene
    {
        private SceneContainer _sceneContainer;
        private Game1 _game;

        public GameScene(Game1 game, SceneContainer sceneContainer)
        {
            _game = game;
            AddSceneContainer(sceneContainer);
        }

        public void AddSceneContainer(SceneContainer sceneContainer)
        {
            _sceneContainer = sceneContainer;

            if (! _game.Components.Contains(sceneContainer))
            {
                _game.Components.Add(sceneContainer);
            }
        }

        public SceneContainer GetSceneContainer()
        {
            return _sceneContainer;
        }
    }
}
