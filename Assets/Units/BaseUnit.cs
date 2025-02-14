using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public Faction Faction;
    public int MaxHealth;
    public int Health;
    public TextMeshPro ActualHeath;

    public void Awake()
    {
        Health = MaxHealth;
        this.ActualHeath.text = this.Health + " / " + this.MaxHealth;
    }

    public void Destroy()
    {
        if (this != null) Destroy(gameObject);
    }

}
