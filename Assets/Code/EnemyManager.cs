using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyManager : MonoBehaviour
{
	private const float SpawnTime = 1f;
	private float LastSpawn;
	private static Object _enemyPrefab;
	// Use this for initialization
	void Start ()
	{
		_enemyPrefab = Resources.Load("Enemy");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((Time.time - LastSpawn) < SpawnTime) return;
		LastSpawn = Time.time;
		Spawn();
	}

	private void Spawn()
	{
		var go = (GameObject) Instantiate(_enemyPrefab);
	}
}
