using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
	private Vector3 enemyPos;
	public Enemy near;
	
	
	// Use this for initialization
	void Start () {	
		GetComponent<Renderer> ().material.color = Color.yellow;
	}

	// Update is called once per frame
	void Update () 
	{
		enemyPos = near.transform.position;
		Vector3 bulletPos = transform.position;
		Vector3 dir = enemyPos  - bulletPos; 
		if (dir.magnitude > 1)
		{
			bulletPos = bulletPos + Vector3.Normalize(dir) * 0.5f;
			transform.position = bulletPos;
		}
		else
		{
			gameObject.SetActive(false);
			if (near.GetHealth() > 0)
			{
				near.SetHealth(50);
			}
			if (near.GetHealth() <= 0)
			{
				if (near.gameObject.activeSelf)
				{
					if (near.GetComponent<Renderer>().material.color == Color.blue)
					{
						Base.dollar += 20;
					}	
					else if (near.GetComponent<Renderer>().material.color == Color.cyan)
					{
						Base.dollar += 10;
					}
					else if (near.GetComponent<Renderer>().material.color == Color.green)
					{
						Base.dollar += 50;
					}
					near.gameObject.SetActive(false);
				}
				
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		Destroy(gameObject);
	}

}