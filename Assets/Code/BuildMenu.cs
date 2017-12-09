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
			public BuildMenu()
			{
				Go = (GameObject)Object.Instantiate(Resources.Load("Build Menu"),Canvas);
				InitializeButtons();
			}

			private void InitializeButtons()
			{
				//3 kinds of build buttons
				var _build = GameObject.Find("Build Normal").GetComponent<Button>();
				var _build_Freeze = GameObject.Find("Build Freeze").GetComponent<Button>();
				var _build_Shock = GameObject.Find("Build Shock").GetComponent<Button>();

				//if money not enough to build a tower, disable menu
				if (Base.dollar < Base.towerprice)
				{
					_build.interactable = false;
					_build_Freeze.interactable = false;
					_build_Shock.interactable = false;
				}
				
				//get the clicked cell
				var cell = GameObject.FindGameObjectWithTag("Clicked");
				
				//if this cell is blockinh enemies from reaching base, disable menu
				if (BlockingAll())
				{
					_build.interactable = false;
					_build_Freeze.interactable = false;
					_build_Shock.interactable = false;
				}
				
				//if there's enemy on this cell, can't build tower here
				if (EnemyOnCell())
				{
					_build.interactable = false;
					_build_Freeze.interactable = false;
					_build_Shock.interactable = false;
				}

				//build regular tower
				_build.onClick.AddListener(() =>
				{
					Base.dollar = Base.dollar - Base.towerprice;//update money
					cell.layer = 9;//change layer to hasTower
					
					//build the tower
					Vector3 towerPos = new Vector3(cell.transform.position.x, cell.transform.position.y+2,cell.transform.position.z);
					var tower = (GameObject)Object.Instantiate(Resources.Load("Tower"),towerPos,Quaternion.identity);
	
					//unselect the cell
					cell.GetComponent<Renderer>().material.color = Color.gray;
					cell.tag = "Cube";
					//select status of other cells 
					GameObject[] disable = GameObject.FindGameObjectsWithTag("Disabled");
					foreach (var cub in disable)
					{
						cub.tag = "Cube";
					}
					Hide();	//hide menu when done			
				});
				
				//build freeze tower
				_build_Freeze.onClick.AddListener(() =>
				{
					Base.dollar = Base.dollar - Base.towerprice;
					cell.layer = 9;
					Vector3 towerPos = new Vector3(cell.transform.position.x, cell.transform.position.y+2,cell.transform.position.z);
					var tower = (GameObject)Object.Instantiate(Resources.Load("FreezeTower"),towerPos,Quaternion.identity);
	
					cell.GetComponent<Renderer>().material.color = Color.gray;
					cell.tag = "Cube";
					GameObject[] disable = GameObject.FindGameObjectsWithTag("Disabled");
					foreach (var cub in disable)
					{
						cub.tag = "Cube";
					}
					Hide();				
				});

				//build shock tower
				_build_Shock.onClick.AddListener(() =>
				{
					Base.dollar = Base.dollar - Base.towerprice;
					cell.layer = 9;
					Vector3 towerPos = new Vector3(cell.transform.position.x, cell.transform.position.y+2,cell.transform.position.z);
					var tower = (GameObject)Object.Instantiate(Resources.Load("ShockTower"),towerPos,Quaternion.identity);
	
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
				GameObject[] disabled = GameObject.FindGameObjectsWithTag("Disabled");
				GameObject clicked = GameObject.FindGameObjectWithTag("Clicked");
				bool[][] map = new bool[5][];//record cells with tower
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
						map[xindex][zindex] = false;//no tower
					}
					else if (cell.layer == 9)
					{
						map[xindex][zindex] = true;//has tower
					}		
				}
				//enemy base
				map[0][4] = false;
				//home base
				map[4][0] = false;
				float x = clicked.transform.position.x;
				float z = clicked.transform.position.z;
				int xind = (int) (x+0.5) / 5;
				int zind = (int) (z+0.5) / 5;
				map[xind][zind] = true;	//asssuming building a tower on clicked cell
				
				int[] start={0,4};
				Queue<int[]> q = new Queue<int[]>();
				q.Enqueue(start);
				visited[0][4] = true;
				
				//traverse 4 directions
				int[] direction = {0, 1, 0, -1, 0};
				
				while (q.Count > 0)
				{
					int[] curr = q.Dequeue();
					int currx = curr[0];
					int currz = curr[1];
					if (currx == 4 && currz == 0)//home base
					{
						return false;//meaning enemies can still reach home base when tower is built on clicked cell
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


			bool EnemyOnCell()
			{
				GameObject clicked = GameObject.FindGameObjectWithTag("Clicked");
				float x = clicked.transform.position.x;
				float z = clicked.transform.position.z;
				GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
				foreach (var enemy in enemies)
				{
					float ex = enemy.transform.position.x;
					float ez = enemy.transform.position.z;
					//if there's an enemy within the range
					if (ex < x + 2.5 && ex > x - 2.5 && ez < z + 2.5 && ez > z - 2.5)
					{
						return true;
					}
				}
				return false;
			}
		}	
	}
}


