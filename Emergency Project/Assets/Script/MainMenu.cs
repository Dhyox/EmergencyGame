using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        GameManager.LastHP = Player.HP;
        GameManager.Score = 0;
        GameManager.EnemyCounter = 0;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
