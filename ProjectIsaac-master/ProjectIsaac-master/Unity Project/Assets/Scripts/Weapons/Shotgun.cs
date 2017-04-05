using UnityEngine;
using System.Collections;

public class Shotgun : Gun {

	void Start() {
		Name = "Shotgun";
		TotalAmmo = 24;
		ClipCapacity = 2;
		BulletsInClip = 2;
		FireRate = 1f;
		Range = 100f;
		Damage = 10;
		Automatic = false;
		ShotDisperses = true;
		Dispersion = new Vector3 (0.005f, 0.005f, 0.005f);
	}

	public override void Shoot(Ray _Ray) {
		if(Can_Shoot()) {
			for (int i = 0; i < 8; i++) {
				if (Physics.Raycast (_Ray.origin, _Ray.direction, out Hit, Range)) {
					if (ShotDisperses)
						_Ray.direction = Disperse (_Ray.direction);
					if (Physics.Raycast (_Ray.origin, _Ray.direction, out Hit, Range)) {
						Spawn_Bullet_Hole (Hit);
						Apply_Effect (Hit);
						Debug.Log (Name + " hit object " + Hit.collider.gameObject.name + " at distance " + Hit.distance);
					}
				}
			}

			BulletsInClip--;
			NextShot = Time.time + FireRate;
		}
	}

	public override void Apply_Effect(RaycastHit _Hit) {
		if ((_Hit.collider.gameObject.transform.parent.GetComponent ("TakeDamage") as TakeDamage != null)) {
			_Hit.collider.gameObject.transform.parent.GetComponent<TakeDamage> ().Take_Damage (Damage, (BoxCollider)Hit.collider);
		}
	}

}
