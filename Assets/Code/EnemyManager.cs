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
		
		if (WaveNumber > 9)
		{
			return;
		}
		
		TargetTime -= Time.deltaTime;
		
		
		if (TargetTime <= 0.0f)
		{
			if (Time.time - LastSpawn > 15f)
			{
				TargetTime = 15f;
				WaveNumber++;
				i = 0;
			}

		}
		else
		{	

			if (WaveNumber == 1)
			{
				if ((Time.time - LastSpawn) < SpawnTime) return;
				

				if (i == 0)
				{
					Debug.Log(Time.time);
				}
				
				if (i < 5)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
				
			}
			
			
			else if (WaveNumber == 2)
			{
				if ((Time.time - LastSpawn) < SpawnTime) return;
				
				if (i == 0)
				{
					Debug.Log(Time.time);
				}
				if (i < 10)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}

			}
			
			else if (WaveNumber == 3)
			{
				
				if ((Time.time - LastSpawn) < SpawnTime) return;
				
				if (i == 0)
				{
					Debug.Log(Time.time);
				}
				if (i < 5)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
				else if (i >= 5 && i < 10)
				{
					LastSpawn = Time.time;
					Spawn(2);
					i++;
				}
				
				else if (i >= 10 && i < 15)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
				
			}
			
			else if (WaveNumber == 4)
			{
				if ((Time.time - LastSpawn) < SpawnTime) return;
				
				if (i == 0)
				{
					Debug.Log(Time.time);
				}
				
				if (i < 5)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
				else if (i >= 5 && i < 7)
				{
					LastSpawn = Time.time;
					Spawn(3);
					i++;
				}
				
				else if (i >= 7 && i < 12)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
			}
			
			else if (WaveNumber == 5)
			{
				if ((Time.time - LastSpawn) < SpawnTime) return;
				
				if (i == 0)
				{
					Debug.Log(Time.time);
				}
				
				if (i < 10)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
				else if (i >= 10 && i < 14)
				{
					LastSpawn = Time.time;
					Spawn(3);
					i++;
				}
				
				else if (i >= 14 && i < 24)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
			}
			
			else if (WaveNumber == 6)
			{
				if ((Time.time - LastSpawn) < SpawnTime) return;
				
				if (i == 0)
				{
					Debug.Log(Time.time);
				}
				
				if (i < 10)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
				else if (i >= 10 && i < 14)
				{
					LastSpawn = Time.time;
					Spawn(3);
					i++;
				}
				
				else if (i >= 14 && i < 24)
				{
					LastSpawn = Time.time;
					Spawn(2);
					i++;
				}
			}
			
			else if (WaveNumber == 7)
			{
				if ((Time.time - LastSpawn) < SpawnTime) return;
				
				if (i == 0)
				{
					Debug.Log(Time.time);
				}
				
				if (i < 5)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
				else if (i >= 5 && i < 7)
				{
					LastSpawn = Time.time;
					Spawn(3);
					i++;
				}
				
				else if (i >= 7 && i < 12)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
			}
			
			else if (WaveNumber == 8)
			{
				if ((Time.time - LastSpawn) < SpawnTime) return;
				
				if (i == 0)
				{
					Debug.Log(Time.time);
				}
				
				if (i < 10)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
				else if (i >= 10 && i < 14)
				{
					LastSpawn = Time.time;
					Spawn(3);
					i++;
				}
				
				else if (i >= 14 && i < 24)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
			}
			
			else if (WaveNumber == 9)
			{
				if ((Time.time - LastSpawn) < SpawnTime) return;
				
				if (i == 0)
				{
					Debug.Log(Time.time);
				}
				
				if (i < 10)
				{
					LastSpawn = Time.time;
					Spawn(1);
					i++;
				}
				else if (i >= 10 && i < 14)
				{
					LastSpawn = Time.time;
					Spawn(3);
					i++;
				}
				
				else if (i >= 14 && i < 24)
				{
					LastSpawn = Time.time;
					Spawn(2);
					i++;
				}
			}

		}
	}

	private void Spawn(int i)
	{
		var go = (GameObject) Instantiate(_enemyPrefab);
		if (i == 1)
		{
			go.GetComponent<Renderer> ().material.color = Color.blue;
			Enemy newE = go.GetComponent<Enemy>();
			newE.enemyHealth = 100;
			//SpawnTime = 0.8f;

		}
		
		//fast
		else if (i == 2)
		{
			go.GetComponent<Renderer> ().material.color = Color.cyan;
			go.transform.localScale -= new Vector3(0.3f,0.3f,0.3f);
			Enemy newE = go.GetComponent<Enemy>();
			newE.enemyHealth = 50;
			//SpawnTime = 0.2f;
		}
		
		else if (i == 3)
		{
			go.GetComponent<Renderer> ().material.color = Color.green;
			go.transform.localScale += new Vector3(0.3f,0.3f,0.3f);
			Enemy newE = go.GetComponent<Enemy>();
			newE.enemyHealth = 200;
			//SpawnTime = 0.8f;
		}
	}
	
	

	
}
