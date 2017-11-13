
using UnityEngine;

namespace Assets.Code.Menus
{
    public partial class UIManager
    {
        public static Transform Canvas { get; private set; }

        private BuildMenu _main;
        private UpgradeMenu _pause;

        public bool InMainMenu { get { return _main != null && _main.Showing; } }

        public UIManager () {
            Canvas = GameObject.Find("Canvas").transform; // There should only ever be one canvas
        }

        public void ShowBuildMenu () {
            _main = new BuildMenu();
            _main.Show();
        }

        public void HideBuildMenu () {
            _main.Hide();
            _main = null;
        }

        public void ShowUpgradeMenu () {
            _pause = new UpgradeMenu();
            _pause.Show();

        } 

        public void HideUpgradeMenu () {
            _pause.Hide();
            _pause = null;
        }



        private abstract class Menu
        {
            protected GameObject Go;
            public bool Showing { get; private set; }

            /// <summary>
            /// Show this menu
            /// </summary>
            public virtual void Show () {
                Showing = true;
                Go.SetActive(true);
            }

            /// <summary>
            /// Hide this menu
            /// </summary>
            public virtual void Hide () {
                GameObject.Destroy(Go);
                Showing = false;
            }
        }
    }

}