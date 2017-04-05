using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDUpdater : MonoBehaviour {

	public PlayerStats PlayerStats;

	public Image Stamina_Bar;

	void Update() {
		Stamina_Bar.fillAmount = (float)PlayerStats.Get_Stamina() / 100;
	}

}
