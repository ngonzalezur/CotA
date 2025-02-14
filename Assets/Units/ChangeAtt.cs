using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeAtt : MonoBehaviour
{
    public BaseAttack Attack;
    public TMP_InputField input;

    private void CambiarDmg(int dmg)
    {
            Attack.Damage = dmg;
    }
    
    public void NuevoDmg()
    {
        if (int.TryParse(input.text, out var dmg)){
            CambiarDmg(dmg);
        }            
    }

}
