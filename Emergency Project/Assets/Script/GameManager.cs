using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int EnemyCounter;
    public static int Score;

    public Canvas PauseMenu;
    bool a;

    public Canvas DmgScrn;
    bool b = false;

    public static int LastHP = 3;

    public void PopUp()
    {
        if (b == false)
        {
            DmgScrn.enabled = true;
            b = true;
        }
        else if (b == true)
        {
            DmgScrn.enabled = false;
            b = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LastHP = Player.HP;
        Score = 0;
        a = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
       // StartCoroutine(BloodPop());
    }
    public IEnumerator BloodPop()
    {

        PopUp();
        yield return new WaitForSeconds(0.050F);
        PopUp();
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PopUpSetting()
    {
        if (a == false)
        {
            PauseMenu.enabled = true;
            a = true;
        }
        else if (a == true)
        {
            PauseMenu.enabled = false;
            a = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.P))
        {
            PopUpSetting();
        }

        if (Player.HP != LastHP)
        {
            StartCoroutine(BloodPop());
            GameManager.Score -= 50;
            LastHP = Player.HP;
        }

        if (EnemyCounter == 0)
        {
            SceneManager.LoadScene("Win");
        }

    }
}
