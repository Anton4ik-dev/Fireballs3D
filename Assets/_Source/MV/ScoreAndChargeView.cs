using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MV
{
    public class ScoreAndChargeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI winScoreText;

        [SerializeField] private Image winScreen;
        [SerializeField] private Image loseScreen;

        [SerializeField] private Slider chargeSlider;
        [SerializeField] private Button restartButton1;
        [SerializeField] private Button restartButton2;

        public void Bind(int charge)
        {
            chargeSlider.maxValue = charge;
            chargeSlider.value = charge;
            restartButton1.onClick.AddListener(Restart);
            restartButton2.onClick.AddListener(Restart);
        }

        public void UpdateChargeView(int charge)
        {
            chargeSlider.value = charge;
        }

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

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}