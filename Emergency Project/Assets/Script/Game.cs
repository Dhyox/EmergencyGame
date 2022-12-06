using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Text HP;
    public Text Ammo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = "HP: " + Player.HP;
        Ammo.text = "Ammo: " + Player.Ammo;
    }
}
