using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyManager : MonoBehaviour
{
	private const float SpawnTime = 0.8f;
	//private const float WaveTime = 10f;
	private float LastSpawn;
	private static Object _enemyPrefab;

	private float TargetTime = 15.0f;
	// Use this for initialization
	void Start ()
	{
		_enemyPrefab = Resources.Load("Enemy");
	}
	
	// Update is called once per frame
	void Update ()
	{
		TargetTime -= Time.deltaTime;
		if (TargetTime <= 0.0f)
		{
			if (Time.time - LastSpawn > 10f)
			{
				TargetTime = 15f;
			}

		}
		else
		{
			if ((Time.time - LastSpawn) < SpawnTime) return;
			LastSpawn = Time.time;
			Spawn();
		}

	}

	private void Spawn()
	{
		var go = (GameObject) Instantiate(_enemyPrefab);
	}
}
