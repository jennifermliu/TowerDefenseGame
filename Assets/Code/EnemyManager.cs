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
	private int i = 0;

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
			Spawn(i);
			i++;

		}

	}

	private void Spawn(int i)
	{
		var go = (GameObject) Instantiate(_enemyPrefab);
		if (i % 3 == 0)
		{
			go.GetComponent<Renderer> ().material.color = Color.blue;
			Enemy newE = go.GetComponent<Enemy>();
			newE.enemyHealth = 100;

		}
		
		else if (i % 3 == 1)
		{
			go.GetComponent<Renderer> ().material.color = Color.cyan;
			Enemy newE = go.GetComponent<Enemy>();
			newE.enemyHealth = 150;
		}
		
		else if (i % 3 == 2)
		{
			go.GetComponent<Renderer> ().material.color = Color.green;
			Enemy newE = go.GetComponent<Enemy>();
			newE.enemyHealth = 200;
		}
	}
	
	

	
}
