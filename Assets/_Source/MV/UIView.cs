using TMPro;
using UnityEngine;

namespace MV
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        public void UpdateScoreText(int score)
        {
            _scoreText.text = $"{score}";
        }
    }
}