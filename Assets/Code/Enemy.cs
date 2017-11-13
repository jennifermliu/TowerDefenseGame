using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class Enemy : MonoBehaviour
{
	//public GameObject ENEMY;
	private	Vector3 pos;
	private Vector3 Basepos;
	//public GameObject _enemy;
	public int enemyHealth;

	public int GetHealth()
	{
		return enemyHealth;
	}

	public void SetHealth(int val)
	{
		enemyHealth = enemyHealth - val;
	}
	
	// Use this for initialization
	void Start () {		
		//_enemy = (GameObject) Instantiate(ENEMY);
		//_enemy.GetComponent<Renderer> ().material.color = Color.blue;
		GetComponent<Renderer> ().material.color = Color.blue;
		enemyHealth = 100;
		//pos = _enemy.transform.position;
		pos = transform.position;
		//Debug.Log(pos);
		//Debug.Log(enemyHealth);		


	}
	
	// Update is called once per frame
	void Update () {
		GameObject _Base = GameObject.FindWithTag("Base");
		Basepos = _Base.transform.position;
		Vector3 dir = Basepos - pos; 
		//Debug.Log(_enemy.transform.position);
		if (dir.magnitude > 2.5)
		{
			pos = pos + Vector3.Normalize(dir) * 0.05f;
			//_enemy.transform.position = pos;
			transform.position = pos;
			//Debug.Log(pos);

		}
		else
		{
			//_enemy.SetActive(false);
			gameObject.SetActive(false);
			if (Base.hit > 0)
			{
				Base.hit = Base.hit - 5;
			}
			
			//Debug.Log(Base.hit);
			//_Base.GetComponent<Base>().hit = _Base.GetComponent<Base>().hit - 10;
			//Debug.Log(_Base.GetComponent<Base>().hit);
		}
		if (enemyHealth <= 0)
		{
			gameObject.SetActive(false);
		}
		


	}


}


