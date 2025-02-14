using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class BaseAttack : MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public int Damage;
    public Faction Faction;
    public int AreaOfEffect;
    public float CoolDown;
    public float LastCast;
    //public TMP_InputField inputDmg;
    //public TMP_InputField inputCool;



    public void Destroy()
    {
        if(this != null) Destroy(gameObject);
    }

    public void DoDamage(BaseUnit unit)
    {
        if (unit.Faction != Faction)
        {
            unit.Health -= Damage;
            unit.ActualHeath.text = unit.Health + " / " + unit.MaxHealth;
        }
    }
    //public void Update()
    //{
        
    //    if (int.TryParse(inputDmg.text, out var dmg) && inputDmg != null && inputDmg.text != "")
    //    {
    //        Damage = dmg;
    //    }
    //    if (float.TryParse(inputCool.text, out var cool) && inputCool != null && inputCool.text != "")
    //    {
    //        CoolDown = cool;
    //    }            
    //}
}
