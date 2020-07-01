using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceGame {
    public class Player : Entity {

        
        public float Speed {get; set;}
        public float RotationSpeed {get; set;}
        private string textureName;
        private Texture2D playerTexture;
        private Texture2D laserTexture;
        private int width;
        private int height;

        public Player(string textureName, Vector2 position, float speed = 1, float rotation = 0, float rotationSpeed = 1) {
            this.textureName = textureName;
            Rotation = rotation;
            Speed = speed;
            RotationSpeed = rotationSpeed;
            Sprite = new Sprite();
            Sprite.Position = position;

            playerTexture = AssetManager.Instance.Assets[textureName];
            Sprite.Texture = playerTexture;
            laserTexture = AssetManager.Instance.Assets["laser"];

            width = playerTexture.Width;
            height = playerTexture.Height;
        }

    

        public override void Draw(SpriteBatch spriteBatch) {
            Rectangle sourceRectangle = new Rectangle(0,0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            
            
            spriteBatch.Draw(Sprite.Texture, Sprite.Position, sourceRectangle, Color.White, Rotation, new Vector2(width/2, height/2), 1, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
            
            KeyboardState state;
            state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A)) {
                Move(Direction.right);
            }
            else if (state.IsKeyDown(Keys.D))
            {
                Move(Direction.left);
            }
            if(state.IsKeyDown(Keys.W)) {
                Move(Direction.forward);
            }
            else if (state.IsKeyDown(Keys.S)) {
                Move(Direction.backward);
            }
            if(state.IsKeyDown(Keys.Space)) {
                Shoot();
            }
        }



        public void Move(Direction direction) {


            if(direction == Direction.left)  {
                this.Rotation = (this.Rotation + RotationSpeed) % (2 * MathHelper.Pi);
            }
            else if (direction == Direction.right)
            {
                this.Rotation = (this.Rotation + (-1 * RotationSpeed)) % (2 * MathHelper.Pi);
            }
            float changeY = 0;
            float changeX = 0;

            if(direction == Direction.forward) {
                changeY += MathF.Cos(Rotation) * Speed;
                changeX -= MathF.Sin(Rotation) * Speed;
            }
            else if (direction == Direction.backward)
            {
                changeY -= MathF.Cos(Rotation) * Speed;
                changeX += MathF.Sin(Rotation) * Speed;
            }

           
            //Check Bounds and Set 
            int screenW = Game1.graphics.PreferredBackBufferWidth ;
            int screenH = Game1.graphics.PreferredBackBufferHeight;

            float X, Y;

            if (changeX + Position.X > screenW) {
                X = screenW;
            }
            else if (changeX + Position.X < 0) {
                X = 0;
            }
            else {
                X = changeX + Position.X;
            }

            if (changeY + Position.Y > screenH) {
                Y = screenH;
            }
            else if (changeY + Position.Y < 0) {
                Y = 0;
            }
            else {
                Y = changeY + Position.Y;
            }

            Sprite.Position = new Vector2(X, Y);
        }

        public void Shoot () {
            Sprite laserSprite = new Sprite(laserTexture);
            laserSprite.Position = Position;
            Projectile laser = new Projectile(laserSprite);
            laser.Rotation = Rotation;
            laser.Speed = 10f;
        }
    }
}
