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

        public string GetPreviousScene()
        {
            return _previousScene;
        }

        public void SwitchScene(string sceneName)
        {
            if (! _scenes.ContainsKey(sceneName))
            {
                return;
            }

            _previousScene = sceneName;
            GameScene scene = _scenes[sceneName];
            GameComponent[] sceneComponents = scene.GetComponents();

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
                new SceneContainerWorldMap(_game, "world-map"),
                new EnterArea(_game, "menuScene", 630, 480, "gameplayScene", this, 60, 60)
            );
            AddScene(
                "gameplayScene",
                new SceneContainerCity(_game, "city"),
                new EnterArea(_game, "gameplayScene", 0, 0, "menuScene", this, 60, 60)
            );
        }

        private void AddScene(string sceneName, params GameComponent[] sceneComponents)
        {
            GameScene scene = new GameScene(_game, sceneComponents);
            _scenes.Add(sceneName, scene);
        }
    }
}
