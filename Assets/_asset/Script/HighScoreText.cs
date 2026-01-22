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
        ResetNewRecord();
    }  

    public void TrySetHighScore(int currentScore)
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
            PlayerPrefs.Save();

            newRecordText.SetActive(true); // ✅ chỉ bật khi phá kỷ lục
            UpdateText();
        }
    }
    //private void Update()
    //{
    //    Debug.Log("Diem hien tai la " + highScore);
    //}
    public void ResetNewRecord()
    {
        if (newRecordText != null)
            newRecordText.SetActive(false);
        UpdateText();
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }

    private void UpdateText()
    {
        text.text = highScore.ToString();
    }
}
