using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "HIGH_SCORE";

    private TextMeshProUGUI text;
    private int highScore;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        // Load điểm cao nhất đã lưu
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        UpdateText();
    }

    public void TrySetHighScore(int currentScore)
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
            PlayerPrefs.Save();
            UpdateText();
        }
    }

    private void UpdateText()
    {
        text.text = " " + highScore;
    }
}
