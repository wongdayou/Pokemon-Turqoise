using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHud : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text levelText;
    [SerializeField] HPBar hpBar;

    // Use Pokemon Class to set name
    public void SetData(Pokemon pokemon)
    {   
        // remember use Name instead of name because the one with caps is the property
        nameText.text = pokemon.Base.Name.ToString();
        levelText.text = pokemon.Level.ToString();
        hpBar.SetHP((float) pokemon.HP / pokemon.MaxHp);
    }

}
