using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Base : MonoBehaviour {

	public GameObject Cylin;
	public Slider Meter;
	public static int hit;
	public GameObject Text;
	public static int dollar;

	// Use this for initialization
	
	
	void Start ()
	{
		hit = 100;
		GameObject _base = (GameObject) Instantiate(Cylin);

		_base.GetComponent<Renderer> ().material.color = Color.red;

		var go = GameObject.Find("Slider");
		Meter = go.GetComponent<Slider>();
		Meter.value = hit;
		//Debug.Log(Meter.value);

		Text = GameObject.FindGameObjectWithTag("Money");
		dollar = 50;
		Text.GetComponent<Text>().text = "$ " + dollar;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Meter.value = hit;
		Text.GetComponent<Text>().text = "$ " + dollar;
	}


}

