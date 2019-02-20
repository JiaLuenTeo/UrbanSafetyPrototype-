using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public static MapGenerator Instance;

	public Vector2 mapSize;
	public GameObject tileGO;
	public float tileScale;
	public Vector2 offset;

	[Range(0,1)]
	public float outlinePercent;

	Vector2 tileSize;
	public GameObject[,] tileMap = new GameObject[0,0];

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		CreateMap();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void CreateMap()
	{
		tileSize.x = tileGO.GetComponent<MeshRenderer>().bounds.size.x;
		tileSize.y = tileGO.GetComponent<MeshRenderer>().bounds.size.z;

		string holderName = "Generated Map";
		if (transform.Find (holderName))
		{
			GameObject.DestroyImmediate(GameObject.Find(holderName));
		}

		Transform mapHolder = new GameObject (holderName).transform;
		mapHolder.parent = transform;

		tileMap = new GameObject[(int)mapSize.x,(int)mapSize.y];

		for (int x = 0; x < mapSize.x; x++)
		{
			for (int y = 0; y < mapSize.y; y++)
			{
				Vector3 gridTransform = new Vector3(mapSize.x/2 + x * -tileSize.x + offset.x, 0.0f, mapSize.y/2 + y * -tileSize.y + offset.y);
				GameObject grid = Instantiate(tileGO, gridTransform,Quaternion.Euler(Vector3.right*90)) as GameObject;
				tileMap[x,y] = grid;
				grid.transform.localScale = new Vector3(tileScale,tileScale,tileScale) * (1-outlinePercent);
				grid.transform.parent = mapHolder;
			}
		}
	}
}
