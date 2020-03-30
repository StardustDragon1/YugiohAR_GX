using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{


    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;

    public int maxMana;
    public int currentMana;

    public int special_mana_cost = 0;

    public bool isDefending = false;



    public bool takeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
            return true;
        else 
            return false;
    }

    public void useMana(int cost)
    {
        currentMana -= cost;
        if (currentMana <= 0)
            currentMana = 0;
    }


    public void Defend()
    {
        isDefending = true;
    }

}
