using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "HIGH_SCORE";

    private TextMeshProUGUI text;
    private int highScore;

    [SerializeField] private GameObject newRecordText;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        LoadHighScore();
        UpdateText();
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

            if (newRecordText != null)
                newRecordText.SetActive(true);

            UpdateText();
        }

    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }

    private void UpdateText()
    {
        if (text == null) return;
        text.text = highScore.ToString();
    }
}
