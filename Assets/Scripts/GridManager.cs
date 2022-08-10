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
    [SerializeField] private GameObject itemFourPrefab;
    [SerializeField] private GameObject itemFivePrefab;
    [SerializeField] private GameObject itemSixPrefab;

    private float itemOneX;
    private float itemTwoX;
    private float itemThreeX;
    private float itemFourX;
    private float itemFiveX;
    private float itemSixX;

    public float itemFourY;
    public float itemSixY;

    public float generateItemOne;
    public float generateItemTwo;
    public float generateItemThree;
    public float generateItemFour;
    public float generateItemFive;
    public float generateItemSix;

    [SerializeField]
    public GameObject canvas;

    public Camera cam;

    private Dictionary<Vector2, Tile> tiles;

    void Awake()
    {
        itemOneX = Random.Range(4, 8);
        itemOneX = Mathf.Round(itemOneX);

        itemTwoX = Random.Range(4, 8);
        itemTwoX = Mathf.Round(itemTwoX);

        itemThreeX = Random.Range(4, 8);
        itemThreeX = Mathf.Round(itemThreeX);

        itemFourX = Random.Range(4, 8);
        itemFourX = Mathf.Round(itemFourX);

        itemFiveX = Random.Range(4, 8);
        itemFiveX = Mathf.Round(itemFiveX);

        itemSixX = Random.Range(4, 8);
        itemSixX = Mathf.Round(itemSixX);

        itemFourY = Random.Range(7, 8);
        itemFourY = Mathf.Round(itemFourY);

        itemSixY = Random.Range(0, 1);
        itemSixY = Mathf.Round(itemSixY);

        generateItemOne = Random.Range(0, 2);
        generateItemOne = Mathf.Round(generateItemOne);

        generateItemTwo = Random.Range(0, 2);
        generateItemTwo = Mathf.Round(generateItemTwo);

        generateItemThree = Random.Range(0, 3);
        generateItemThree = Mathf.Round(generateItemThree);

        generateItemFour = Random.Range(0, 4);
        generateItemFour = Mathf.Round(generateItemFour);

        generateItemFive = Random.Range(0, 3);
        generateItemFive = Mathf.Round(generateItemFive);

        generateItemSix = Random.Range(0, 4);
        generateItemSix = Mathf.Round(generateItemSix);
    }

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < width; x++)
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

        if (generateItemOne == 1)
        {
            var spawnedItemOne = Instantiate(itemOnePrefab, new Vector3(itemOneX, 3, -1), Quaternion.identity);
            spawnedItemOne.name = $"Item One";
        }

        if (generateItemTwo == 1)
        {
            var spawnedItemTwo = Instantiate(itemTwoPrefab, new Vector3(itemTwoX, 5, -1), Quaternion.identity);
            spawnedItemTwo.name = $"Item Two";
        }

        if (generateItemThree == 1)
        {
            var spawnedItemThree = Instantiate(itemThreePrefab, new Vector3(itemThreeX, 6, -1), Quaternion.identity);
            spawnedItemThree.name = $"Item Three";
        }

        if (generateItemFour == 1)
        {
            var spawnedItemFour = Instantiate(itemFourPrefab, new Vector3(itemFourX, itemFourY, -1), Quaternion.identity);
            spawnedItemFour.name = $"Item Four";
        }

        if (generateItemFive == 1)
        {
            var spawnedItemFive = Instantiate(itemFivePrefab, new Vector3(itemFiveX, 2, -1), Quaternion.identity);
            spawnedItemFive.name = $"Item Five";
        }

        if (generateItemSix == 1)
        {
            var spawnedItemSix = Instantiate(itemSixPrefab, new Vector3(itemSixX, itemSixY, -1), Quaternion.identity);
            spawnedItemSix.name = $"Item Six";
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f,-10);

        
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }

}
