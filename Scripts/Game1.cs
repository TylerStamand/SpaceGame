
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceGame
{

    public enum Direction {
        forward,
        backward,
        left,
        right
    }

    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;

        public ScoreManager scoreManager;
        public EntityManager entityManager;
        public StateManager stateManager;

        public AssetManager assetManager;
        private SpriteBatch spriteBatch;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //These declerations need to happen in order to start the Load function
            stateManager = StateManager.Instance;
            assetManager = AssetManager.Instance;
            scoreManager = ScoreManager.Instance;
            entityManager = EntityManager.Instance;
           

            

          
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            stateManager.Load(Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            stateManager.Update(gameTime);

            base.Update(gameTime);
            
       
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.White);
            

            spriteBatch.Begin();

            spriteBatch.Draw(Content.Load<Texture2D>("spaceBackground"), new Vector2(0,0), Color.White);
            stateManager.Draw(spriteBatch);
            
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
