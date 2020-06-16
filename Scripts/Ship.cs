using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace SpaceGame {
    public class Ship {

        StateManager stateManager = StateManager.Instance;

        public Texture2D Texture {get; set;}
        public Vector2 Position {get; set;}
        public float Rotation {get; set;}
        public float Speed {get; set;}
        public float RotationSpeed {get; set;}

        private int width;
        private int height;

        public Ship(Texture2D texture, Vector2 position, float speed = 1, float rotation = 0, float rotationSpeed = 1) {
            Texture = texture;
            Position = position;
            Rotation = rotation;
            Speed = speed;
            RotationSpeed = rotationSpeed;

            width = Texture.Width;
            height = Texture.Height;


            stateManager.UpdateEvent += new StateManager.UpdateHandler(Update);

        }

        public void Draw(SpriteBatch spriteBatch) {
            Rectangle sourceRectangle = new Rectangle(0,0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, Rotation, new Vector2(width/2, height/2), SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime) {
            Console.WriteLine("Update");
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

            Position = new Vector2(X, Y);
        }

        public void Shoot () {
            
        }
    }
}
        

            


         
           
        
        
