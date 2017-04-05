using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour {

	public Text DebugText;

	public Camera Camera;
	public GameObject BulletHole;

	public List<Gun> Guns = new List<Gun>();

	int Gun = 0;

	RaycastHit Hit;

	void Update() {

		if(Input.GetKeyDown(KeyCode.F)) {
			foreach(Gun _Gun in Guns) {
				_Gun.Add_Ammo (1000);
			}
		}

		if(Guns[Gun].Is_Automatic()) {
			if(Input.GetButton("Fire1")) {
				Shoot ();
			}
		}
		else {
			if(Input.GetButtonDown("Fire1")) {
				Shoot();
			}
		}

		if(Input.GetKeyDown(KeyCode.R)) {
			Guns [Gun].Reload();
		}

		if(Input.GetKeyDown(KeyCode.E)) {
			Gun = Gun + 1 < Guns.Count ? Gun + 1 : 0;
		}

		if(Input.GetKeyDown(KeyCode.Q)) {
			Gun = Gun - 1 >= 0 ? Gun - 1 : Guns.Count - 1;
		}

		DebugText.text = Guns [Gun].Get_Info();


	}

	void Shoot() {
		Ray Ray = Camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
		Guns [Gun].Shoot (Ray);
	}

}
