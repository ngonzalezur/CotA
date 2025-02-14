using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeHealthHero : MonoBehaviour
{
    public TMP_InputField input;
    public void Activar()
    {
        if (int.TryParse(input.text, out var hel))
            CanvaManager.Instance.CambiarVidaHeroe(hel);
    }
}
