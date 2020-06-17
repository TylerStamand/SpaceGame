using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame {
    public class Sprite {
        public Texture2D Texture {get; set;}
        public Vector2 Position {get; set;}

        public float Rotation {get; set;}

        public Sprite() {
            
        }

        public Sprite(Texture2D texture) {
            Texture = texture;
        }

        public Sprite(Texture2D texture, Vector2 position) {
            Texture = texture;
            Position = position;
        }

    }
}