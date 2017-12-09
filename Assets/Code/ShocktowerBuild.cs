using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class ShocktowerBuild : MonoBehaviour
{
	
	private float ShockTime = 5f;
	private float LastShock;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = Color.black;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Base.end)
		{
			return;
		}
		if ((Time.time - LastShock) < ShockTime) return;
		float xpos = transform.position.x;
		float zpos = transform.position.z;
		Enemy[] enemies = FindObjectsOfType(typeof(Enemy)) as Enemy[];
		Enemy target1=null;
		float dist = float.MaxValue;
		if (target1 == null)
		{
			foreach (Enemy e in enemies)
			{
				Vector3 enemypos=e.transform.position;
				if (enemypos.x < xpos + 7.5 && enemypos.x > xpos - 7.5 && enemypos.z < zpos + 7.5 && enemypos.z > zpos - 7.5)
				{
					float currdist = (enemypos.x - xpos) * (enemypos.x - xpos) + (enemypos.z - zpos) * (enemypos.z - zpos);
					if (currdist < dist)
					{
						target1 = e;
						dist = currdist;
					}
				}
			}
		}
		if (dist == float.MaxValue)
		{
			return;
		}
		target1.enemyHealth = target1.enemyHealth*0.5;
		StartCoroutine(ColorHold(target1));
		var temp1 = target1;
		target1 = null;
		Enemy target2=null;
		dist = float.MaxValue;
		Vector3 pos1 = temp1.transform.position;
		if (target2 == null)
		{
			foreach (Enemy e in enemies)
			{
				if (e == temp1)
				{
					continue;
				}
				Vector3 enemypos=e.transform.position;
				if (enemypos.x < pos1.x + 7.5 && enemypos.x > pos1.x - 7.5 && enemypos.z < pos1.z + 7.5 && enemypos.z > pos1.z - 7.5)
				{
					float currdist = (enemypos.x - pos1.x) * (enemypos.x - pos1.x) + (enemypos.z - pos1.z) * (enemypos.z - pos1.z);
					if (currdist < dist)
					{
						target2 = e;
						dist = currdist;
					}
				}
			}
		}
		if (dist == float.MaxValue)
		{
			return;
		}
		target2.enemyHealth = target2.enemyHealth*0.5;
		StartCoroutine(ColorHold(target2));
		var temp2 = target2;
		target2 = null;
		Enemy target3=null;
		dist = float.MaxValue;
		Vector3 pos2 = temp2.transform.position;
		foreach (Enemy e in enemies)
		{
			if (e == temp1 || e==temp2)
			{
				continue;
			}
			Vector3 enemypos=e.transform.position;
			if (enemypos.x < pos2.x + 7.5 && enemypos.x > pos2.x - 7.5 && enemypos.z < pos2.z + 7.5 && enemypos.z > pos2.z - 7.5)
			{
				float currdist = (enemypos.x - pos2.x) * (enemypos.x - pos2.x) + (enemypos.z - pos2.z) * (enemypos.z - pos2.z);
				if (currdist < dist)
				{
					target3 = e;
					dist = currdist;
				}
			}
		}
		if (dist == float.MaxValue)
		{
			return;
		}
		target3.enemyHealth = target3.enemyHealth*0.5;
		StartCoroutine(ColorHold(target3));
		target3 = null;
		LastShock = Time.time;
	}

		

	IEnumerator ColorHold(Enemy target)
	{
		var originalcolor = target.GetComponent<Renderer>().material.color;
		target.GetComponent<Renderer>().material.color = Color.black;
		yield return new WaitForSeconds(1);
		target.GetComponent<Renderer>().material.color = originalcolor;
	}

}
