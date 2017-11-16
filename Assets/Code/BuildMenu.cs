using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Menus
{
	public partial class UIManager
	{
		
		private class BuildMenu : Menu
		{

			
			//public static GameObject Go;

			public BuildMenu()
			{
				Go = (GameObject)Object.Instantiate(Resources.Load("Build Menu"),Canvas);
				InitializeButtons();
		
		
			}

			private void InitializeButtons()
			{
				var _build = GameObject.Find("Build").GetComponent<Button>();

				if (Base.dollar < 50)
				{
					_build.interactable = false;
				}
				var cell = GameObject.FindGameObjectWithTag("Clicked");
				if (BlockingAll())
				{
					_build.interactable = false;
				}
				_build.onClick.AddListener(() =>
				{
					Base.dollar = Base.dollar - 50;
					//var cell = GameObject.FindGameObjectWithTag("Clicked");
					cell.layer = 9;
					Vector3 towerPos = new Vector3(cell.transform.position.x, cell.transform.position.y+2,cell.transform.position.z);
					var tower = (GameObject)Object.Instantiate(Resources.Load("Tower"),towerPos,Quaternion.identity);
	
					cell.GetComponent<Renderer>().material.color = Color.gray;
					cell.tag = "Cube";
					GameObject[] disable = GameObject.FindGameObjectsWithTag("Disabled");
					foreach (var cub in disable)
					{
						cub.tag = "Cube";
					}
					Hide();				
				});

			}

			private bool BlockingAll()
			{
				GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
				GameObject[] disabled = GameObject.FindGameObjectsWithTag("Disabled");
				GameObject clicked = GameObject.FindGameObjectWithTag("Clicked");
				GameObject enemybase = GameObject.FindGameObjectWithTag("EnemyBase");
				GameObject homebase = GameObject.FindGameObjectWithTag("HomeBase");
				bool[][] map = new bool[5][];
				for (int i = 0; i < 5; i++)
				{
					map[i] = new bool[5];
				}
				foreach (var cell in disabled)
				{
					float xval = cell.transform.position.x;
					float zval = cell.transform.position.z;
					int xindex = (int) (xval + 0.5) % 5;
					int zindex = (int) (zval + 0.5) % 5;
					Debug.Log(xval);
					Debug.Log(zval);
					Debug.Log(xindex);
					Debug.Log(zindex);
				}
				/*
				Dictionary<GameObject,bool> dict = new Dictionary<GameObject, bool>();
				dict[enemybase] = false;
				dict[homebase] = false;
				//if a tower is built here
				dict[clicked] = true;
				foreach (var cell in cubes)
				{
					if (cell.layer == 8)//no tower
					{
						dict[cell] = false;
					}
					else if (cell.layer == 9)//has tower
					{
						dict[cell] = true;
					}
				}
				*/
				
				//Queue<GameObject>
				return false;
			}

		}	
	}
}


