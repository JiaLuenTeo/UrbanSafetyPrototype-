using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public enum State
    {
        START,
        SPAWNING,
        STOP,
    };

    private static SpawnManager mInstance = null;
    public static SpawnManager Instance;
    State curState;


    [Header("Picture to Level")]
    public List<Texture2D> levelsImageList = new List<Texture2D>();
    public Texture2D levelImage;
    public Color32 floorColour = Color.blue;
    public Color32 goalColour = Color.red;
    byte[,] levelData;
    [Header ("Prefabs")]
    public GameObject floorPrefab;
    public GameObject goalBlockPrefab;
    public GameObject wallPrefab;
    public GameObject playerPrefab;

    public GameObject[,] cellsTable;
    internal object position;

    void Awake()
    {

    }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {

    }

    public void generateLevelData()
    {
        levelData = new byte[levelImage.width, levelImage.height];
        cellsTable = new GameObject[levelImage.width, levelImage.height];
        for (byte x = 0; x < levelImage.width; x++)
        {
            for (byte y = 0; y < levelImage.height; y++)
            {
                Color32 data = levelImage.GetPixel(x, y);
                Debug.Log(data);
                
                if (data.Equals(floorColour))
                {
                    levelData[x, y] = 1;
                }
                if (data.Equals(goalColour))
                {
                    levelData[x, y] = 5;
                }
            }
        }
    }

    public void buildLevel()
    {
        for (byte x = 0; x < levelImage.width ; x++)
        {
            for (byte y = 0; y < levelImage.height  ; y++)
            {

                Vector3 position;
                position.x = x * 6f;
                position.y = 0f;
                position.z = y * 6f;

                switch (levelData[x, y])
                {
                    case 0:
                        break;

                    case 1:
                        GameObject floor = Instantiate<GameObject>(floorPrefab);
                        floor.transform.SetParent(transform, false);
                        floor.transform.position = position;
                        break;

                    case 5:
                        
                        break;

                    case 10:
                       
                        break;

                    case 100:
                        
                        break;
                }
            }
        }
       
       curState = State.STOP;
    }


    /*
    void CreateCell(int x, int y, int i)
    {
        Vector3 position;
        position.x = x * 10f;
        position.y = 0f;
        position.z = y * 10f;

        if (isSpawning)
        {
            SquareCellInfo cell = Instantiate<SquareCellInfo>(squareCellPrefab);
            cellsTable[x,y] = cell;
            cell.transform.SetParent(transform, false);
            cell.transform.localPosition = position;
            cell.cellXY = new Vector2Int(x, y);

            if (isSpawningNumbers)
            {
                Text label = Instantiate<Text>(cellLabelPrefab);
                label.rectTransform.SetParent(gridCanvas.transform, false);
                label.rectTransform.anchoredPosition =
                    new Vector2(position.x, position.z);
                label.text = "X" + x.ToString() + "\n" + "Y" + y.ToString();
            }

            if (isSpawningWall && x == (width - 1) && y == 0)
            {
                CreateWalls(0,0,x, y, false);
            }
            else if (isSpawningWall && x == 0 && y == (height - 1))
            {
                CreateWalls(0,0, x, y, false);
            }
        }
    }

    void CreateWalls(int x1, int y1, int x2, int y2, bool rotateWall)
    {
        GameObject wall = Instantiate<GameObject>(wallPrefab);
        Vector3 scale = wallPrefab.transform.localScale;
        Vector3 endPosition = new Vector3(cellsTable[x2, y2].GetComponent<Renderer>().bounds.max.x, cellsTable[x2, y2].GetComponent<Renderer>().bounds.min.y, cellsTable[x2, y2].GetComponent<Renderer>().bounds.min.z);
        scale.x = Vector3.Distance(cellsTable[x1,y1].GetComponent<Renderer>().bounds.min, endPosition);
        wallPrefab.transform.localScale = scale;

        wall.transform.position = cellsTable[x1,y1].GetComponent<Renderer>().bounds.min + wall.GetComponent<Renderer>().bounds.size / 2;
        if (rotateWall) wall.transform.Rotate(new Vector3(0,180));
    }
    */
}
