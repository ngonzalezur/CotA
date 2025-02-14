using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeAttCoolDown : MonoBehaviour
{
    public BaseAttack Attack;
    public TMP_InputField input;

    private void CambiarCool(float cool)
    {
        Attack.CoolDown = cool;
    }


    public void NuevoCool()
    {
        if (float.TryParse(input.text, out var cool))
        {
            CambiarCool(cool);
        }
    }
}
