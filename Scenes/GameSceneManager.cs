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

        public GameSceneManager(Game1 game)
        {
            _game = game;
            _scenes = new Dictionary<string, GameScene>();
            AddScenes();
        }

        public void SwitchScene(string sceneName)
        {
            if (! _scenes.ContainsKey(sceneName))
            {
                return;
            }

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
            AddScene("gameplayScene", new SceneContainerCity(_game, "city"));
        }

        private void AddScene(string sceneName, params GameComponent[] sceneComponents)
        {
            GameScene scene = new GameScene(_game, sceneComponents);
            _scenes.Add(sceneName, scene);
        }
    }
}
