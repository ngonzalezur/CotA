using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnHeroes:
                UnitManager.Instance.SpawnHeroes();
                break;
            case GameState.SpawnEnemies:
                UnitManager.Instance.SpawnEnemies();
                break;
            case GameState.GenerateUI:
                CanvaManager.Instance.AssignAttack();
                CanvaManager.Instance.PutSprites();
                this.ChangeState(GameState.HeroesTurn);
                CanvaManager.Instance.CanSprites = true;
                break;
            case GameState.HeroesTurn:
                UnitManager.Instance.CanPlay = true;
                break;
            case GameState.EndFight:
                UnitManager.Instance.CanPlay = false;
                CanvaManager.Instance.CanSprites = false;
                Debug.Log("GG");
                this.ChangeState(GameState.End);
                break;
            case GameState.End:
                
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnHeroes = 1,
    SpawnEnemies = 2,
    HeroesTurn = 3,
    EndFight = 4,
    End = 5,
    GenerateUI = 6
}