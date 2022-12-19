using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MV
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI winScoreText;
        [SerializeField] private Image winScreen;
        [SerializeField] private Image loseScreen;
        public void UpdateScoreText(int score)
        {
            scoreText.text = $"{score}";
            winScoreText.text = $"{score}";
        }
        public void TurnOnWinScreen()
        {
            winScreen.gameObject.SetActive(true);
        }
        public void TurnOnLoseScreen()
        {
            loseScreen.gameObject.SetActive(true);
        }
        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}