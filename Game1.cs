using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrusadingNobles.Entities;

namespace CrusadingNobles
{
    public class Game1 : Game
    {
        public int screenWidth;
        public int screenHeight;
        public NamedEntity mob;
        public GameSceneManager gameSceneManager;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            screenWidth = 1280;
            screenHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public SpriteBatch GetSpriteBatch()
        {
            return _spriteBatch;
        }

        public void ToggleComponentState(GameComponent component, bool enabled)
        {
            component.Enabled = enabled;

            if (component is DrawableGameComponent)
            {
                ((DrawableGameComponent)component).Visible = enabled;
            }
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ApplyChanges();
            gameSceneManager = new GameSceneManager(this);
            mob = new NamedEntity();

            foreach (GameComponent component in Components)
            {
                ToggleComponentState(component, false);
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            gameSceneManager.SwitchScene("menuScene");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
