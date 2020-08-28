using MonoGame.UI.Forms;
using Microsoft.Xna.Framework;
using System;
namespace SpaceGame {
    public class GUI : ControlManager {
        public GUI(Game game) : base(game) {

        }

        public override void InitializeComponent() {
            InititiallizeUpgradeButtons();
            // button.Clicked += Button_Clicked;
         
            // Controls.Add(button);
        }

        private void Button_Clicked(object sender, EventArgs e) {
            Button btn = sender as Button;
            btn.BackgroundColor = Color.Green;
            EntityManager.Instance.Player.UpgradeWeapon();
        }


        private void InititiallizeUpgradeButtons() {
            Button upgradeWeaponBtn = new Button()
            {
                Text = "Upgrade Weapon",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.Red
            };

        }
    }
}
