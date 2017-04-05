using UnityEngine;
using System.Collections;

public class DeathRay : Gun {

	void Start() {
		Name = "Death Ray";
		TotalAmmo = 99999;
		ClipCapacity = 99999;
		BulletsInClip = 99999;
		FireRate = 0f;
		Range = 99999f;
		Damage = 99999;
		Automatic = true;
		ShotDisperses = false;
	}

	public override void Apply_Effect(RaycastHit _Hit) {
		if ((_Hit.collider.gameObject.transform.parent.GetComponent ("TakeDamage") as TakeDamage != null)) {
			_Hit.collider.gameObject.transform.parent.GetComponent<TakeDamage> ().Take_Damage (Damage, (BoxCollider)Hit.collider);
		}
	}

}
