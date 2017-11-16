using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

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
				bool[][] visited=new bool[5][];
				for (int i = 0; i < 5; i++)
				{
					map[i] = new bool[5];
					visited[i]=new bool[5];
				}
				foreach (var cell in disabled)
				{
					float xval = cell.transform.position.x;
					float zval = cell.transform.position.z;
					int xindex = (int) (xval+ 0.5) / 5;
					int zindex = (int) (zval+0.5) / 5;
					if (cell.layer == 8)
					{
						map[xindex][zindex] = false;
					}
					else if (cell.layer == 9)
					{
						map[xindex][zindex] = true;
					}
					//Debug.Log(xval+" "+zval+" "+xindex+" "+zindex);		
				}
				//enemy base
				map[0][4] = false;
				//home base
				map[4][0] = false;
				float x = clicked.transform.position.x;
				float z = clicked.transform.position.z;
				int xind = (int) (x+0.5) / 5;
				int zind = (int) (z+0.5) / 5;
				map[xind][zind] = true;
				Debug.Log(x+" "+z+" "+xind+" "+zind);		
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
				int[] start={0,4};
				//var start= new Tuple<int, int>(0,4);
				
				Queue<int[]> q = new Queue<int[]>();
				q.Enqueue(start);
				visited[0][4] = true;
				int[] direction = {0, 1, 0, -1, 0};
				while (q.Count > 0)
				{
					int[] curr = q.Dequeue();
					int currx = curr[0];
					int currz = curr[1];
					if (currx == 4 && currz == 0)
					{
						return false;
					}
					for (int i = 0; i < direction.Length - 1; i++)
					{
						int newx = currx + direction[i];
						int newz = currz + direction[i + 1];
						if (newx < 0 || newx > 4 || newz < 0 || newz > 4)
						{
							continue;
						}
						if (!visited[newx][newz] && !map[newx][newz])
						{
							int[] next = {newx, newz};
							visited[newx][newz] = true;
							q.Enqueue(next);
						}
					}
				}
				return true;
			}
			
		
		}	
	}
}


