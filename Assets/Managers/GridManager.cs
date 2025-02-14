using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] public int _width, _height;

    [SerializeField] private Tile _grassfile, _enemytile;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    public static GridManager Instance;

    void Awake()
    {
        Instance = this;
    }

    //void Start()
    //{
    //    GenerateGrid();
    //}

    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var typeOfTile = x < _width / 2 ? _grassfile : _enemytile;
                var spawnedTile = Instantiate(typeOfTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);


                _tiles[new Vector2(x, y)] = spawnedTile;
                spawnedTile.x = x;
                spawnedTile.y = y;
            }
        }

        //_cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}