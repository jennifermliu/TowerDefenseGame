using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ICON : MonoBehaviour
{
	public Object icon;
	
	// Use this for initialization
	void Start () {
		icon = Resources.Load("ICON");
		float xpos = 55;
		for (int i = 1; i <= 9; i++)
		{
			GameObject newicon = (GameObject) Instantiate(icon,GameObject.Find("Canvas").transform);
			var texts = newicon.GetComponentsInChildren<Text>();
			Vector3 newpos=new Vector3();
			foreach (var _text in texts)
			{
				if (_text.name == "NumWave")
				{
					_text.text = "Wave: " + i;
				}
				if (i == 1)
				{
					if (_text.name == "first")
					{
						_text.text = "5 normal";
					}
				}
				else if (i == 2)
				{
					if (_text.name == "first")
					{
						_text.text = "10 normal";
					}
				}
				else if (i == 3)
				{
					if (_text.name == "first")
					{
						_text.text = "5 normal";
					}
					else if (_text.name == "second")
					{
						_text.text = "5 fast";
					}
					else if (_text.name == "third")
					{
						_text.text = "5 normal";
					}
				}
				else if (i == 4)
				{
					if (_text.name == "first")
					{
						_text.text = "5 normal";
					}
					else if (_text.name == "second")
					{
						_text.text = "2 strong";
					}
					else if (_text.name == "third")
					{
						_text.text = "5 normal";
					}
				}
				else if (i == 5)
				{
					if (_text.name == "first")
					{
						_text.text = "10 normal";
					}
					else if (_text.name == "second")
					{
						_text.text = "4 strong";
					}
					else if (_text.name == "third")
					{
						_text.text = "10 normal";
					}
				}
				else if (i == 6)
				{
					if (_text.name == "first")
					{
						_text.text = "10 normal";
					}
					else if (_text.name == "second")
					{
						_text.text = "4 strong";
					}
					else if (_text.name == "third")
					{
						_text.text = "10 fast";
					}
				}
				else if (i == 7)
				{
					if (_text.name == "first")
					{
						_text.text = "5 normal";
					}
					else if (_text.name == "second")
					{
						_text.text = "2 strong";
					}
					else if (_text.name == "third")
					{
						_text.text = "5 normal";
					}
				}
				else if (i == 8)
				{
					if (_text.name == "first")
					{
						_text.text = "10 normal";
					}
					else if (_text.name == "second")
					{
						_text.text = "4 strong";
					}
					else if (_text.name == "third")
					{
						_text.text = "10 normal";
					}
				}
				else if (i == 9)
				{
					if (_text.name == "first")
					{
						_text.text = "10 normal";
					}
					else if (_text.name == "second")
					{
						_text.text = "4 strong";
					}
					else if (_text.name == "third")
					{
						_text.text = "10 fast";
					}
				}
			}
			float mul = 5;
			if (i == 1)
			{
				newpos=new Vector3(xpos, newicon.transform.position.y, newicon.transform.position.z);
			}
			else if (i == 2)
			{
				xpos = xpos+35*mul;
				newpos=new Vector3(xpos, newicon.transform.position.y, newicon.transform.position.z);
			}
			else if (i == 3)
			{
				xpos = xpos+40*mul;
				newpos=new Vector3(xpos, newicon.transform.position.y, newicon.transform.position.z);
			}
			else if (i == 4)
			{
				xpos = xpos+47*mul;
				newpos=new Vector3(xpos, newicon.transform.position.y, newicon.transform.position.z);
			}
			else if (i == 5)
			{
				xpos = xpos+43*mul;
				newpos=new Vector3(xpos, newicon.transform.position.y, newicon.transform.position.z);
			}
			else if (i == 6)
			{
				xpos = xpos+58*mul;
				newpos=new Vector3(xpos, newicon.transform.position.y, newicon.transform.position.z);
			}
			else if (i == 7)
			{
				xpos = xpos+58*mul;
				newpos=new Vector3(xpos, newicon.transform.position.y, newicon.transform.position.z);
			}
			else if (i == 8)
			{
				xpos = xpos+43*mul;
				newpos=new Vector3(xpos, newicon.transform.position.y, newicon.transform.position.z);
			}
			else if (i == 9)
			{
				xpos = xpos+58*mul;
				newpos=new Vector3(xpos, newicon.transform.position.y, newicon.transform.position.z);
			}
			newicon.transform.position = newpos;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Base.hit <= 0)
		{
			return;
		}
		GameObject[] allicons = GameObject.FindGameObjectsWithTag("ICON");
		foreach (var icon in allicons)
		{
			icon.transform.position = icon.transform.position + 0.182f*Vector3.left;
			if (icon.transform.position.x < 50)
			{
				icon.gameObject.SetActive(false);
			} 
		}	
	}
}