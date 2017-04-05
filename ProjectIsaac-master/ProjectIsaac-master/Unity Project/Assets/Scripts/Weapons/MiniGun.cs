using UnityEngine;
using System.Collections;

public class MiniGun : Gun {

	void Start() {
		Name = "Mini Gun";
		TotalAmmo = 200;
		ClipCapacity = 100;
		BulletsInClip = 100;
		FireRate = 0.025f;
		Range = 150f;
		Damage = 5;
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
