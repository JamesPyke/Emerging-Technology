using UnityEngine;
using System.Collections;

public class MachineGun : Gun {

	void Start() {
		Name = "Machine Gun";
		TotalAmmo = 64;
		ClipCapacity = 32;
		BulletsInClip = 32;
		FireRate = 0.05f;
		Range = 150f;
		Damage = 15;
		Automatic = true;
		ShotDisperses = true;
		Dispersion = new Vector3 (0.0005f, 0.0005f, 0.0005f);
	}

	public override void Apply_Effect(RaycastHit _Hit) {
		if((_Hit.collider.gameObject.transform.parent.GetComponent ("TakeDamage") as TakeDamage != null)) {
			_Hit.collider.gameObject.transform.parent.GetComponent<TakeDamage> ().Take_Damage (Damage, (BoxCollider)Hit.collider);
		}
	}

}
