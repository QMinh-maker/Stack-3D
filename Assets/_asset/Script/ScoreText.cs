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
        GameManager.OnCubeSpawn += OnCubeSpawn;
    }

    private void OnDisable()
    {
        GameManager.OnCubeSpawn -= OnCubeSpawn;
    }

    public void ResetScore() // gọi khi Start Game
    {
        score = 0;
        text.text = "0";

        if (highScoreText != null)
            highScoreText.ResetNewRecord();
    }

    private void OnCubeSpawn()
    {
        score++;
        text.text = score.ToString();
    }
}
