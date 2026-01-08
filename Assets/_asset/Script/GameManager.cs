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

    private bool gameStarted = false;

    private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // CLICK LẦN ĐẦU → ẨN BUTTON MENU
            if (!gameStarted)
            {
                gameStarted = true;

                if (buttonMenu != null)
                    buttonMenu.SetActive(false);
            }

            // LOGIC STACK GAME
            if (MovingCube.CurrentCube != null)
            {
                MovingCube.CurrentCube.Stop();
            }

            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];
            currentSpawner.SpawnCube();
            OnCubeSpawn();
        }
    }
}
