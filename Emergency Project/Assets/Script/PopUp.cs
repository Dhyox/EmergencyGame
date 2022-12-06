using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public Canvas SettingMenu;
    public Canvas BuyMenu;
    bool a = false;
    bool b = false;
    public void PopUpSetting()
    {
        if (a == false)
        {
            SettingMenu.enabled = true;
            a = true;
        }
        else if (a == true)
        {
            SettingMenu.enabled = false;
            a = false;
        }
    }
    public void PopUpBuy()
    {
        if (b == false)
        {
            BuyMenu.enabled = true;
            b = true;
        }
        else if (b == true)
        {
            BuyMenu.enabled = false;
            b = false;
        }
    }

}
