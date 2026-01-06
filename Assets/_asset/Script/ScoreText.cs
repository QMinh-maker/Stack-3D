using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text;
    private bool hasStarted = false;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "0";
        GameManager.OnCubeSpawn += GameManager_OnCubeSpawn;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawn -= GameManager_OnCubeSpawn;
    }

    private void GameManager_OnCubeSpawn()
    {
        // Bỏ qua lần spawn đầu tiên (bắt đầu game)
        if (!hasStarted)
        {
            hasStarted = true;
            return;
        }

        score++;
        text.text = "" + score;
    }
}
