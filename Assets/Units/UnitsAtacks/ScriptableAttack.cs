using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Attack")]

public class ScriptableAttack : ScriptableObject
{
    public BaseAttack AttackPrefab;
    public Faction Faction;
}

