using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Picker3D.UI
{
    public class DuringGamePanelController : MonoBehaviour
    {
        public static DuringGamePanelController instance;


        [SerializeField] private GameObject retryButton;
        [SerializeField] private TMP_Text levelText;

        //[SerializeField] private TMP_Text coinText;


        void Awake()
        {
            instance = this;
            levelText.text = $"LEVEL {GameManager.Level}";
        }

        

        public void RetryButtonHandle()
        {
            LevelManager.gameState = GameState.BeforeStart;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //public void UpdateCoin(int amount)
        //{
        //    var before = GameManager.Coin;
        //    GameManager.Coin += amount;
        //    DOTween.To(() => before, x => before = x, GameManager.Coin, 1).OnUpdate(() => coinText.text = before + string.Empty);
        //}

        public void Activator()
        {
            retryButton.SetActive(true);
            levelText.text = $"LEVEL {GameManager.Level}";
            levelText.transform.parent.gameObject.SetActive(true);
        }

        public void LevelTextSetter()
        {
            if (GameManager.Level!=1)
            {
                levelText.text = $"LEVEL {GameManager.Level}";
            }
        }

    }
}
