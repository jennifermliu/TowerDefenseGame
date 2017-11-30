using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
	private float SpawnTime = 0.6f;
	private float LastSpawn;
	private static Object _enemyPrefab;
	private int i = 0;
	public GameObject NumWaveText;
	public static int WaveNumber;
	

	private float TargetTime = 15.0f;
	// Use this for initialization
	void Start ()
	{
		_enemyPrefab = Resources.Load("Enemy");
		WaveNumber = 1;
		NumWaveText = GameObject.FindGameObjectWithTag("NumWave");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Base.end)
		{
			return;
		}
		
		if (WaveNumber > 5)
		{
			return;
		}
		TargetTime -= Time.deltaTime;
		if (TargetTime <= 0.0f)
		{
			if (Time.time - LastSpawn > 10f)
			{
				TargetTime = 15f;
				WaveNumber++;
				i = 0;
			}

		}
		else
		{
			
			
			
			if ((Time.time - LastSpawn) < SpawnTime) return;

			if (i <= 29)
			{
				LastSpawn = Time.time;
				Spawn(i);
				i++;
			}
			


		}

	}

	private void Spawn(int i)
	{
		var go = (GameObject) Instantiate(_enemyPrefab);
		if (i % 5 == 0)
		{
			go.GetComponent<Renderer> ().material.color = Color.blue;
			Enemy newE = go.GetComponent<Enemy>();
			newE.enemyHealth = 100;
			//SpawnTime = 0.8f;

		}
		
		//fast
		else if (i % 5 == 1 || i % 5 == 2 || i % 5 == 3)
		{
			go.GetComponent<Renderer> ().material.color = Color.cyan;
			go.transform.localScale -= new Vector3(0.3f,0.3f,0.3f);
			Enemy newE = go.GetComponent<Enemy>();
			newE.enemyHealth = 50;
			//SpawnTime = 0.2f;
		}
		
		else if (i % 5 == 4)
		{
			go.GetComponent<Renderer> ().material.color = Color.green;
			go.transform.localScale += new Vector3(0.3f,0.3f,0.3f);
			Enemy newE = go.GetComponent<Enemy>();
			newE.enemyHealth = 200;
			//SpawnTime = 0.8f;
		}
	}
	
	

	
}
