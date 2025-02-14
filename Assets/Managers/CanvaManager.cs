using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvaManager : MonoBehaviour
{
    public static CanvaManager Instance;

    [SerializeField] private List<Sprite> SpritesAtt;
    public List<Sprite> SpritesTemp = new List<Sprite>();
    [SerializeField] private Transform canvasTransform;

    public bool CanSprites = false;

    //public GameObject indicator;
    void Awake()
    {
        Instance = this;

        SpritesAtt = new List<Sprite>(Resources.LoadAll<Sprite>("Sprites/AttSprites"));
    }
    public void AssignAttack()
    {
        var i = UnitManager.Instance._attackS.Count;
        foreach (Sprite sprite in SpritesAtt)
        {
            sprite.attS = UnitManager.Instance._attackS[i-1].AttackPrefab;
            i--;
        }
    }

    public void Cooldowns()
    {
        foreach (Sprite sprite in SpritesTemp)
        {
            if (Time.time >= sprite.attS.LastCast + sprite.attS.CoolDown)
            {
                sprite.texto.text = "";
                sprite.indicator.SetActive(false);
            }
            else
            {
                sprite.indicator.SetActive(true);
                var tiempoC = sprite.attS.LastCast + sprite.attS.CoolDown - Time.time;
                sprite.texto.text = (tiempoC).ToString("F2");
            }
            
        }
    }

    public void PutSprites()
    {
        foreach(Sprite sprite in SpritesAtt)
        {
            Sprite nuevoUI = Instantiate(sprite, canvasTransform);
            SpritesTemp.Add(nuevoUI);
        }
    }

    public void CambiarVidaHeroe(int hel)
    {
        foreach (BaseUnit hero in UnitManager.Instance.AllUnits)
        {
            if (hero.Faction == Faction.Hero)
            {
                hero.MaxHealth = hel;
                hero.Health = hero.MaxHealth;
                hero.ActualHeath.text = hero.Health + " / " + hero.MaxHealth;
            }
        }
    }

    public void CambiarVidaEnemigo(int hel)
    {
        foreach (BaseUnit enemy in UnitManager.Instance.AllUnits)
        {
            if (enemy.Faction == Faction.Enemy)
            {
                enemy.MaxHealth = hel;
                enemy.Health = enemy.MaxHealth;
                enemy.ActualHeath.text = enemy.Health + " / " + enemy.MaxHealth;
            }
        }
        
    }

    public void CambiarVelocidadEnemigo(float vel)
    {
        foreach (BaseUnit enemy in UnitManager.Instance.AllUnits)
        {
            if (enemy.Faction == Faction.Enemy)
            {
                UnitManager.Instance.TimeMoveEne = vel;
            }
        }
    }

    public void CambiarVelocidadAttBasic(float vel)
    {
        foreach (BaseUnit enemy in UnitManager.Instance.AllUnits)
        {
            if (enemy.Faction == Faction.Enemy)
            {
                UnitManager.Instance.TimeAttEne = vel;
            }
        }
    }

    public void Restablecer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Update()
    {
        Cooldowns();
    }

}
