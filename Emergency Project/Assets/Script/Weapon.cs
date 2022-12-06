using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform FirePoint;
    public GameObject BulletPref;

    // Update is called once per frame
    void Update()
    {
        if (!Player.pauseToggle)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                Player.Ammo -= 1;
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                    Player.Ammo -= 1;
                }
            }
        }
    }

    void Shoot()
    {
        Instantiate(BulletPref, FirePoint.position, FirePoint.rotation);
    }

}
