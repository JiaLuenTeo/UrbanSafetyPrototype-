using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public enum States
	{
		IDLE,
		SPAWNING,
		ROUNDONGOING,
		ROUNDENDED,
		ROUNDINTERMISSION
	}

	public GameObject enemyGo;
	public List<int> enemyPerRound = new List<int>();
	public int currentRound;

	public States curState;
	public States preState;

	Vector3 spawnLocation;

	int[,] SpawnLocation = new int[0,0];

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (curState == States.IDLE)
		{
			startSpawning();
		}
		else if (curState == States.ROUNDONGOING)
		{
			checkForEnemies();
		}
		else if (curState == States.ROUNDINTERMISSION)
		{
			waitForNextRound();
		}
		else if (curState == States.ROUNDENDED)
		{
			checkVictoryCondition();
		}

	}

	void startSpawning()
	{
		Vector2 mapSize = MapGenerator.Instance.mapSize;

		curState = States.SPAWNING;

		for (int i = 0; i < enemyPerRound[currentRound]; i++)
		{
			
			int X = Random.Range(0, (int)mapSize.x);
			int Y = Random.Range(0, (int)mapSize.y);

			spawnLocation = MapGenerator.Instance.tileMap[X,Y].transform.position;

			Instantiate(enemyGo,spawnLocation,Quaternion.identity);
		}

		curState = States.ROUNDONGOING;
	}

	void checkForEnemies()
	{
		GameObject[] enemySpawned = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemySpawned.Length <= 0)
		{
			currentRound++;
			curState = States.ROUNDENDED;
		}
			
	}

	void checkVictoryCondition()
	{
		if (currentRound == enemyPerRound.Count)
		{
			
		}
		else 
		{
			curState = States.ROUNDINTERMISSION;
		}
	}

	void waitForNextRound()
	{
		
	}
}
