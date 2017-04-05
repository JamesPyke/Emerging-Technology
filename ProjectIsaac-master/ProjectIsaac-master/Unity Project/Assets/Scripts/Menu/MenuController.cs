using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

	public List<MenuItem> MenuItems = new List<MenuItem>();
	int Selected = 0;

	void Update() {

		MenuItems [Selected].Select ();

		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
			MenuItems [Selected].Deselect ();
			Selected = Selected - 1 >= 0 ? Selected - 1 : MenuItems.Count - 1;
		}

		if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
			MenuItems [Selected].Deselect ();
			Selected = Selected + 1 < MenuItems.Count ? Selected + 1 : 0;
		}

		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
			MenuItems [Selected].Run_Action ();
		}

	}

}
