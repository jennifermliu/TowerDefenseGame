using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
	private Vector3 enemyPos;
	public Enemy near;//initialized in bullet manager
	
	
	// Use this for initialization
	void Start () {	
		GetComponent<Renderer> ().material.color = Color.yellow;
	}

	// Update is called once per frame
	void Update () 
	{
		enemyPos = near.transform.position;
		Vector3 bulletPos = transform.position;
		Vector3 dir = enemyPos  - bulletPos;//directio nthat the bullet should shoot at
		if (dir.magnitude > 1)//if bullet not reached, uodate bullet position
		{
			bulletPos = bulletPos + Vector3.Normalize(dir) * 0.5f;
			transform.position = bulletPos;
		}
		else //if bullet reached 
		{
			gameObject.SetActive(false);
			if (near.GetHealth() > 0)
			{
				near.SetHealth(50);//substract health from enemy
			}
			if (near.GetHealth() <= 0)//if enemy is now dead
			{
				if (near.gameObject.activeSelf)//still active
				{
					//reward for killing enemy
					if (near.GetComponent<Renderer>().material.color == Color.blue)//regular enemyz
					{
						Base.dollar += 20;
					}	
					else if (near.GetComponent<Renderer>().material.color == Color.cyan)//fast enemy
					{
						Base.dollar += 10;
					}
					else if (near.GetComponent<Renderer>().material.color == Color.green)//strong enemy
					{
						Base.dollar += 50;
					}
					near.gameObject.SetActive(false);//make it unactive
				}
				
			}
		}
	}

	//destroy bullet if it collides with something
	private void OnCollisionEnter2D(Collision2D other)
	{
		Destroy(gameObject);
	}

}