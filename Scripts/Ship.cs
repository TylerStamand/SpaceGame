using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace SpaceGame {
    public class Ship {

        private StateManager stateManager = StateManager.Instance;
        public float Rotation {get; set;}
        public float Speed {get; set;}
        public float RotationSpeed {get; set;}
        public Vector2 Position {
            get {
                return shipSprite.Position;
            }
            set {
                shipSprite.Position = value;
            }
        }

        private string textureName;
        private Texture2D shipTexture;
        private Sprite shipSprite;
        private Texture2D laserTexture;
        private int width;
        private int height;

        public Ship(string textureName, Vector2 position, float speed = 1, float rotation = 0, float rotationSpeed = 1) {
            this.textureName = textureName;
            Rotation = rotation;
            Speed = speed;
            RotationSpeed = rotationSpeed;
            shipSprite = new Sprite();
            shipSprite.Position = position;
            
        
            stateManager.DrawEvent += new StateManager.DrawHandler(Draw);
            stateManager.LoadEvent += new StateManager.LoadHandler(Load);
            stateManager.UpdateEvent += new StateManager.UpdateHandler(Update);

            

        }

        public void Load(ContentManager content) {
            shipTexture = content.Load<Texture2D>(textureName);
            shipSprite.Texture = shipTexture;
            laserTexture = content.Load<Texture2D>("laser");

            width = shipTexture.Width;
            height = shipTexture.Height;
        }

        public void Draw(SpriteBatch spriteBatch) {
            Rectangle sourceRectangle = new Rectangle(0,0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            
            spriteBatch.Draw(shipSprite.Texture, shipSprite.Position, sourceRectangle, Color.White, Rotation, new Vector2(width/2, height/2), 1, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime) {
         
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

            shipSprite.Position = new Vector2(X, Y);
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
        

            


         
           
        
        
