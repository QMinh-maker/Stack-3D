using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        GameManager.OnCubeSpawn += GameManager_OnCubeSpawn;
    }
    private void OnDestroy()
    {
        GameManager.OnCubeSpawn -= GameManager_OnCubeSpawn;
    }

    private void GameManager_OnCubeSpawn()
    {
        score++;
        text.text = "Score: " + score;
    }


}
