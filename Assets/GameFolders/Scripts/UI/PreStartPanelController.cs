using UnityEngine;
using UnityEngine.UI;

namespace Picker3D.UI
{
    public class PreStartPanelController : MonoBehaviour
    {
        void Start()
        {
            if (GameManager.Level <= 1) return;
            gameObject.SetActive(false);
            GetComponent<Button>().enabled = false;
            DuringGamePanelController.instance.Activator();
            LevelManager.gameState = GameState.Normal;
        }
        public void GameStarterButton()
        {
            LevelManager.gameState = GameState.Normal;
            gameObject.SetActive(false);
            DuringGamePanelController.instance.Activator();
        }
    }
}
