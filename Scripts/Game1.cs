
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
        public StateManager stateManager;
        private SpriteBatch spriteBatch;
  



        private Ship ship;


        private KeyboardState state;

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            stateManager = StateManager.Instance;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            ship = new Ship("ship", new Vector2(240,240), 3, MathHelper.ToRadians(180), .1f);
            stateManager.Load(Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            ship.Load(Content);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A)) {
                ship.Move(Direction.right);
            }
            else if (state.IsKeyDown(Keys.D))
            {
                ship.Move(Direction.left);
            }
            if(state.IsKeyDown(Keys.W)) {
                ship.Move(Direction.forward);
            }
            else if (state.IsKeyDown(Keys.S)) {
                ship.Move(Direction.backward);
            }
            if(state.IsKeyDown(Keys.Space)) {
                ship.Shoot();
            }
            
            stateManager.Update(gameTime);

            base.Update(gameTime);
            
       
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Gray);
            
      
            spriteBatch.Begin();
            stateManager.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
