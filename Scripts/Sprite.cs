using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame {
    public class Sprite {
        public Texture2D Texture {get; set;}
        public Vector2 Position {get; set;}
        public float Rotation {get; set;}
        public Color Color {get; set;} = Color.White;

        public int Width {get {
            return Texture.Width;
        }}

        public int Height {get {
            return Texture.Height;
        }}
        public Sprite() {
            
        }

        public Sprite(Texture2D texture) {
            Texture = texture;
        }

        public Sprite(Texture2D texture, Vector2 position) {
            Texture = texture;
            Position = position;
        }

        public Sprite(Texture2D texture, Vector2 position, Color color)
        {
            Texture = texture;
            Position = position;
            Color = color;
        }

    }
}