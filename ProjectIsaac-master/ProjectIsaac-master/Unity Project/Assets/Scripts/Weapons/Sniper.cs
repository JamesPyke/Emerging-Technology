using UnityEngine;
using System.Collections;

public class Sniper : Gun {

	void Start() {
		Name = "Sniper Rifle";
		TotalAmmo = 32;
		ClipCapacity = 1;
		BulletsInClip = 1;
		FireRate = 0.1f;
		Range = 250f;
		Damage = 50;
		Automatic = true;
		ShotDisperses = true;
		Dispersion = new Vector3 (0.0005f, 0.0005f, 0.0005f);
	}

	public override void Apply_Effect(RaycastHit _Hit) {
		if((_Hit.collider.gameObject.transform.parent.GetComponent("TakeDamage") as TakeDamage != null)) {
			_Hit.collider.gameObject.transform.parent.GetComponent<TakeDamage> ().Take_Damage (Damage, (BoxCollider)Hit.collider);
		}
	}
}
