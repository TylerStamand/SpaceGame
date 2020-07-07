using MonoGame.UI.Forms;
using Microsoft.Xna.Framework;
using System;
namespace SpaceGame {
    public class GUI : ControlManager {
        public GUI(Game game) : base(game) {

        }

        public override void InitializeComponent() {
            Button button = new Button() {
                Text = "UnClicked",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.DarkGray
            };
            
            button.Clicked += Button_Clicked;
            button.MouseUp += Button_MouseUp;
            Controls.Add(button);
        }

        private void Button_Clicked(object sender, EventArgs e) {
            Button btn = sender as Button;
            btn.Text = "Clicked";
        }

        private void Button_MouseUp(object sender, EventArgs e) {
            Button btn = sender as Button;
            btn.Text = "Released";
            ScoreManager.Instance.Score += 1;
        }
    }
}
