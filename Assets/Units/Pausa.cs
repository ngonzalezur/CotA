using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject menu;
    private bool pause = true;

    public void Pausar()
    {
        menu.SetActive(!menu.activeSelf);

    }

    public void Pause()
    {
        if (pause)
        {
            Time.timeScale = 0f;
            pause = false;
        }
        else
        {
            Time.timeScale = 1f;
            pause = true;
        }
    }

}
