using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnCubeSpawn = delegate { };

    private CubeSpawner[] spawners;
    private int spawnerIndex;
    private CubeSpawner currentSpawner;

    [Header("UI")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject Score;

    [SerializeField] private GameObject ResetMenu;


    private bool gameStarted = false;
    public static GameManager Instance;
  
    private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
        Instance = this;
    }

    // ❌ KHÔNG dùng click chuột để start nữa
    private void Update()
    {
        if (!gameStarted) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (MovingCube.CurrentCube != null)
                MovingCube.CurrentCube.Stop();

            // ⚠ KIỂM TRA LẠI
            if (gameStarted)
                SpawnNextCube();
        }
    }

    // ✅ ĐƯỢC GỌI BỞI NÚT BẤM VÔ HÌNH
    public void StartGame()
    {
        if (gameStarted) return;

        gameStarted = true;
        //newRecordText.SetActive(false);

        if (MainMenu != null)
            MainMenu.SetActive(false);

        if (StartMenu != null)
            StartMenu.SetActive(false);

        if (Score != null)
            Score.SetActive(true);

        SpawnNextCube(); // spawn cube đầu tiên
    }

    public void GameOver()
    {
        gameStarted = false;   // 🔒 KHÓA UPDATE
        ResetMenu.SetActive(true);
        MainMenu.SetActive(true);

    }

    public void Return()
    {
        ResetMenu.SetActive(false);
        StartMenu.SetActive(true);
        Score.SetActive(false);
        SceneManager.LoadScene(0);
    }

    private void SpawnNextCube()
    {
        spawnerIndex = spawnerIndex == 0 ? 1 : 0;
        currentSpawner = spawners[spawnerIndex];
        currentSpawner.SpawnCube();
        OnCubeSpawn();
    }
}

