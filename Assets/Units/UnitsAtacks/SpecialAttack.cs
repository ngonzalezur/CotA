using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public int Damage;
    public Faction Faction;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
