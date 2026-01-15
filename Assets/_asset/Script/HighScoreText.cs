using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "HIGH_SCORE";

    private TextMeshProUGUI text;
    private int highScore;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }

    private void OnEnable()
    {
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
        if (text == null) return; // an toàn tuyệt đối
        text.text = highScore.ToString();
    }
}
