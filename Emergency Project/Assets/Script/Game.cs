using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Text HP;
    public Text Ammo;
    public Text Enemy;
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = "HP: " + Player.HP;
        Ammo.text = "Ammo: " + Player.Ammo;
        Enemy.text = "Enemy Left: " + GameManager.EnemyCounter;
        Score.text = "" + GameManager.Score;
    }
}
