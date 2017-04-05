using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour {
	
	public GameObject BulletHoleDecal;
	protected RaycastHit Hit;
	protected string Name;
	protected int ClipCapacity, TotalAmmo, BulletsInClip, Damage;
	protected float FireRate, Range, NextShot;
	protected bool Automatic, ShotDisperses;
	protected Vector3 Dispersion;

	public virtual void Shoot(Ray _Ray) {
		if(Can_Shoot()) {

			if(Physics.Raycast(_Ray.origin, _Ray.direction, out Hit, Range)) {
				if(ShotDisperses) _Ray.direction = Disperse(_Ray.direction);
				if(Physics.Raycast(_Ray.origin, _Ray.direction, out Hit, Range)) {
					Spawn_Bullet_Hole(Hit);
					Apply_Effect(Hit);
					//Debug.Log (Name + " hit object " + Hit.collider.gameObject.name + " at distance " + Hit.distance);
				}
			}

			BulletsInClip--;
			NextShot = Time.time + FireRate;
		}
	}

	public virtual Vector3 Disperse(Vector3 _Shot) {
		_Shot.x += Random.Range (-(Hit.distance * Dispersion.x), Hit.distance * Dispersion.x);
		_Shot.y += Random.Range (-(Hit.distance * Dispersion.y), Hit.distance * Dispersion.y);
		_Shot.z += Random.Range (-(Hit.distance * Dispersion.z), Hit.distance * Dispersion.z);
		return _Shot;
	}

	public virtual void Reload() {
		if(TotalAmmo >= ClipCapacity - BulletsInClip) {
			int BulletsToAdd = ClipCapacity - BulletsInClip;
			TotalAmmo -= BulletsToAdd;
			BulletsInClip += BulletsToAdd;
		}	
	}

	public virtual void Spawn_Bullet_Hole(RaycastHit _Hit) {
		var BulletHole = Instantiate (BulletHoleDecal);
		BulletHole.transform.position = new Vector3(_Hit.point.x * 0.9999f, _Hit.point.y + 0.0001f, _Hit.point.z * 0.9999f);
		BulletHole.transform.rotation = Quaternion.FromToRotation (Vector3.forward * 1f, _Hit.normal);
		BulletHole.transform.SetParent (_Hit.collider.gameObject.transform);		
	}

	public virtual bool Can_Shoot() {
		return BulletsInClip > 0 && Time.time > NextShot;
	}
		
	public abstract void Apply_Effect (RaycastHit _Hit);

	public virtual string Get_Info() {
		return "Weapon Name: " + Name + "\n" + "Damage: " + Damage + "\n" + "Bullets In Clip: " + BulletsInClip + "\n" +
			"Total Ammo: " + TotalAmmo + "\n" + "Automatic: " + Automatic + "\n" + "Fire Rate: " + FireRate + "\n" +
			"Next Shot: " + (NextShot - Time.time > 0 ? (NextShot - Time.time).ToString() : "Ready") + "\n" + "Range: " + Range + "\n" +
			"Clip Capacity: " + ClipCapacity + "\n" + "Disperses: " + ShotDisperses + "\n" + "Dispersion: " + Dispersion.ToString("F4");
	}
		
	public virtual bool Is_Automatic() {
		return Automatic;
	}

	public virtual void Add_Ammo(int _Amount) {
		TotalAmmo += _Amount;
	}

}
