using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenu : Charapter
{

    public void DamageUp()
    {
        if (Souls >= 3)
        {
            Charapter.UPdamage++;
        Charapter.Souls = Charapter.Souls - 3;
        }
    }
    public void SpeedUp()
    {
        if (Souls >= 3)
        { 
            speed = speed + 1f;
            Souls = Souls - 3;
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
