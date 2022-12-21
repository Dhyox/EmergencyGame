using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScore : MonoBehaviour
{
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Score.text = "SCORE: " + GameManager.Score;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}