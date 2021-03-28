using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrusadingNobles
{
    public class GameScene
    {
        private List<GameComponent> _components;
        private Game1 _game;

        public GameScene(Game1 game, params GameComponent[] components)
        {
            _game = game;
            _components = new List<GameComponent>();

            foreach (GameComponent component in components)
            {
                AddComponent(component);
            }
        }

        public void AddComponent(GameComponent component)
        {
            _components.Add(component);

            if (! _game.Components.Contains(component))
            {
                _game.Components.Add(component);
            }
        }

        public GameComponent[] GetComponents()
        {
            return _components.ToArray();
        }
    }
}
