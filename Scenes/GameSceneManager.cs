using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrusadingNobles
{
    public class GameSceneManager
    {
        private Dictionary<string, GameScene> _scenes;
        private Game1 _game;
        private string _previousScene;

        public GameSceneManager(Game1 game)
        {
            _previousScene = null;
            _game = game;
            _scenes = new Dictionary<string, GameScene>();
            AddScenes();
        }

        public GameScene GetGameScene(string sceneName)
        {
            return _scenes[sceneName];
        }

        public void SwitchScene(string sceneName)
        {
            if (! _scenes.ContainsKey(sceneName))
            {
                return;
            }

            _previousScene = sceneName;
            GameScene scene = _scenes[sceneName];
            SceneContainer sceneContainer = scene.GetSceneContainer();
            List<GameComponent> sceneComponents = sceneContainer.sceneComponents;
            sceneComponents.Add(sceneContainer);

            foreach (GameComponent component in _game.Components)
            {
                bool isUsed = sceneComponents.Contains(component);
                _game.ToggleComponentState(component, isUsed);
            }

            Mouse.SetCursor(MouseCursor.Arrow);
        }

        private void AddScenes()
        {
            AddScene(
                "menuScene",
                new SceneContainerWorldMap(_game, "world-map", "menuScene", "World Map")
            );
            AddScene(
                "gameplayScene",
                new SceneContainerCity(_game, "city", "gameplayScene", "The City")
            );
        }

        private void AddScene(string sceneName, SceneContainer sceneContainer)
        {
            GameScene scene = new GameScene(_game, sceneContainer);
            _scenes.Add(sceneName, scene);
        }
    }
}
