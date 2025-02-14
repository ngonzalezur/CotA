using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeSpeedBasicsAttacks : MonoBehaviour
{
    public TMP_InputField input;
    public void Activar()
    {
        if (float.TryParse(input.text, out var speed))
            CanvaManager.Instance.CambiarVelocidadAttBasic(speed);
    }
}
