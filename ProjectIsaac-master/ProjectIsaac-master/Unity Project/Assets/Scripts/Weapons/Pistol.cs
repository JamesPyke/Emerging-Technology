using UnityEngine;
using System.Collections;

public class Pistol : Gun {

	void Start() {
		Name = "Pistol";
		TotalAmmo = 60;
		ClipCapacity = 12;
		BulletsInClip = 12;
		FireRate = 0.25f;
		Range = 100f;
		Damage = 10;
		Automatic = false;
		ShotDisperses = true;
		Dispersion = new Vector3 (0.0005f, 0.0005f, 0.0005f);
	}
		
	public override void Apply_Effect(RaycastHit _Hit) {
		if((_Hit.collider.gameObject.transform.parent.GetComponent("TakeDamage") as TakeDamage != null)) {
			_Hit.collider.gameObject.transform.parent.GetComponent<TakeDamage> ().Take_Damage (Damage, (BoxCollider)Hit.collider);
		}
	}

}
