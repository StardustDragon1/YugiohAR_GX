using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

    public Text nameText;
    public Text levelText;
    public Slider HPBar;
    public Slider ManaBar;


    public void setHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl. " + unit.unitLevel;
        HPBar.value = unit.currentHP;
    }

    public void setHP(int ammount)
    {
        HPBar.value = ammount;
    }

    public void setMana(int ammount)
    {
        ManaBar.value = ammount;

    }

}
