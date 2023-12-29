using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject panelGameOver;
    public bool gameOver;

    void Awake()
    {
        gameOver = false;
    }

    void GameOver()
    {
        gameOver = true;
        panelGameOver.SetActive(true);
    }

}
