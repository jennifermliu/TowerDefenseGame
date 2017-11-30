using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezetowerBuild : MonoBehaviour {

	public Enemy nearest;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		if (Base.end)
		{
			return;
		}
		
		Enemy[] enemys = FindObjectsOfType(typeof(Enemy)) as Enemy[];


	}
}
