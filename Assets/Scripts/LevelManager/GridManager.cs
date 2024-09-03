using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public bool doDevMode = false;
    public float offsetX, offsetY;
    public GameObject [,] grid;



    void Awake()
    {
	Debug.Log("GridManager Awake");
    }

    void OnEnable()
    {
	Debug.Log("GridManager OnEnable");
    }

    void Start()
    {
	Debug.Log("GridManager Start");
    }

    public void GenerateGrid()
    {
	for(int x = 0; x < grid.GetLength(0); x++)
	{
	    for(int y = 0; y < grid.GetLength(1); y++)
	    {
		grid[x,y] = InstantiateTile(x,y);
	    }
	}
    }

    private GameObject InstantiateTile(int x, int y)
    {
	float posX = (tilePrefab.transform.localScale.x * (float)x) + offsetX;
	float posY = (tilePrefab.transform.localScale.y * (float)y) + offsetY;

	var spawnedTile = Instantiate(tilePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
	spawnedTile.name = $"Tile({x}:{y})";
	spawnedTile.GetComponent<GridCell>().DevMode = doDevMode;

	return spawnedTile;
    }
}
