using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopGame : MonoBehaviour
{
    [SerializeField] private GameObject buttonMenu;
    

    public void StartGame()
    {
        if (buttonMenu != null)
        {
            buttonMenu.SetActive(false);
        }
    }
}
