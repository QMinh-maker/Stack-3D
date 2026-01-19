using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text;

    [SerializeField] private HighScoreText highScoreText;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ResetScore();
        GameManager.OnCubeSpawn += OnCubeSpawn;
    }

    private void OnDisable()
    {
        GameManager.OnCubeSpawn -= OnCubeSpawn;
    }

    private void OnCubeSpawn()
    {
        score++;
        text.text = score.ToString();

        if (highScoreText != null)
            highScoreText.TrySetHighScore(score);
    }

    public void ResetScore()
    {
        score = 0;
        text.text = "0";
    }
}
