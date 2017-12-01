using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class Base : MonoBehaviour {

	public GameObject Cylin;//base
	public Slider Meter;//slider to indicate base health
	public static int hit;//value on slider 
	public GameObject Text;//text for displaying dollar
	public static float dollar;//amount of money to spend
	public static bool end;//indicate if the game has ended
	public static float towerprice;//price of building a tower
	
	void Start ()
	{
		end = false;
		hit = 1000;
		towerprice = 100;
		
		GameObject _base = (GameObject) Instantiate(Cylin);
		_base.GetComponent<Renderer> ().material.color = Color.red;

		var go = GameObject.Find("Slider");
		Meter = go.GetComponent<Slider>();
		Meter.value = hit;
		
		Text = GameObject.FindGameObjectWithTag("Money");
		dollar = 1500;
		Text.GetComponent<Text>().text = "$ " + dollar;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (end)//don't update if game has ended
		{
			return;
		}
		if (hit <= 0)//lose if health is less than or equal to 0
		{
			//display lose message
			Instantiate(Resources.Load("Lose"),GameObject.Find("Canvas").transform);
			end = true;
			return;
		}
		
		//update slider with current bar
		Meter.value = hit;  
		Text.GetComponent<Text>().text = "$ " + dollar;
		
		//when wavenumber is set to 9, check if all enemies are gone, if so, winning
		if (EnemyManager.WaveNumber > 8)
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (var enemy in enemies)
			{
				if (enemy.gameObject.activeSelf)
				{
					return;//can end searching if at least one enemy is active
				}
			}
			//display win message if no enemy is active
			Instantiate(Resources.Load("Win"),GameObject.Find("Canvas").transform);
			end = true;
		}
	}


}

