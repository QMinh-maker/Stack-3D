using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnCubeSpawn = delegate { };

    private CubeSpawner[] spawners;
    private int spawnerIndex;
    private CubeSpawner currentSpawner;

    [Header("UI")]
    [SerializeField] private GameObject buttonMenu;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject Score;

    private bool gameStarted = false;

    private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
    }

    // ❌ KHÔNG dùng click chuột để start nữa
    private void Update()
    {
        if (!gameStarted) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (MovingCube.CurrentCube != null)
                MovingCube.CurrentCube.Stop();

            SpawnNextCube();
        }
    }

    // ✅ ĐƯỢC GỌI BỞI NÚT BẤM VÔ HÌNH
    public void StartGame()
    {
        if (gameStarted) return;

        gameStarted = true;

        if (buttonMenu != null)
            buttonMenu.SetActive(false);

        if (StartMenu != null)
            StartMenu.SetActive(false);

        if (Score != null)
            Score.SetActive(true);

        SpawnNextCube(); // spawn cube đầu tiên
    }

    private void SpawnNextCube()
    {
        spawnerIndex = spawnerIndex == 0 ? 1 : 0;
        currentSpawner = spawners[spawnerIndex];
        currentSpawner.SpawnCube();
        OnCubeSpawn();
    }
}



