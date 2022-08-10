using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject playerOnePrefab;
    [SerializeField] private GameObject playerTwoPrefab;
    [SerializeField] private GameObject itemOnePrefab;
    [SerializeField] private GameObject itemTwoPrefab;
    [SerializeField] private GameObject itemThreePrefab;

    [SerializeField]
    public GameObject canvas;



    public Camera cam;
    private Dictionary<Vector2, Tile> tiles;

    void Awake()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < width;  x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x}, {y}";

                
            }
        }
        //var spawnedPlayerOne = Instantiate(playerOnePrefab, new Vector3(0, 4, -1), Quaternion.identity);
        //spawnedPlayerOne.name = $"Player One";

        //var spawnedPlayerTwo = Instantiate(playerTwoPrefab, new Vector3(11, 4, -1), Quaternion.identity);
        //spawnedPlayerTwo.name = $"Player Two";

        var spawnedItemOne = Instantiate(itemOnePrefab, new Vector3(7, 5, -1), Quaternion.identity);
        spawnedItemOne.name = $"Item One";

        var spawnedItemTwo = Instantiate(itemTwoPrefab, new Vector3(4, 8, -1), Quaternion.identity);
        spawnedItemTwo.name = $"Item Two";

        var spawnedItemThree = Instantiate(itemThreePrefab, new Vector3(5, 0, -1), Quaternion.identity);
        spawnedItemThree.name = $"Item Three";

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f,-10);
        GameObject gameCanvas = Instantiate(canvas, canvas.transform.parent);
        gameCanvas.name = $"Canvas";

    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }

}
