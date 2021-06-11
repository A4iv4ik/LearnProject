using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenu : Charapter
{

    public void DamageUp()
    {
        if (Souls >= 3)
        {
            UPdamage=UPdamage+0.1f;
        Souls = Souls - 3;
        }
    }
    public void SpeedUp()
    {
        if (Souls >= 3)
        {
            if (speed<10f)
            {
            speed = speed + 0.5f;
            Souls = Souls - 3;
            }
        }
    }
    public void Heal()
    {
        if (Souls>=3)
        {
        health = health + MAXhealhh * 0.25f;
        Souls = Souls - 3;
        }
    }
}
