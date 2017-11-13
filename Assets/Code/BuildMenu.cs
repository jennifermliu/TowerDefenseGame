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

				_build.onClick.AddListener(() =>
				{
					Base.dollar = Base.dollar - 50;
					var cell = GameObject.FindGameObjectWithTag("Clicked");
					cell.layer = 9;
					Vector3 towerPos = new Vector3(cell.transform.position.x, cell.transform.position.y+2,cell.transform.position.z);
					var tower = (GameObject)Object.Instantiate(Resources.Load("Tower"),towerPos,Quaternion.identity);
	
					cell.GetComponent<Renderer>().material.color = Color.gray;
					cell.tag = "Cube";
					GameObject[] cubes = GameObject.FindGameObjectsWithTag("Disabled");
					foreach (var cub in cubes)
					{
						cub.tag = "Cube";
					}
					Hide();				
				});

			}

		}	
	}
}


