using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TakeDamage : MonoBehaviour {

	public int Health = 100;

	[System.Serializable]
	public struct Hitbox {
		public BoxCollider Collider;
		public int DamageMultiplier;
	};
		
	public List<Hitbox> Hitboxes = new List<Hitbox> ();

	public void Take_Damage (int _Amount, BoxCollider _Collider) {
		
		for(int i = 0; i < Hitboxes.Count; i++) {
			if(_Collider == Hitboxes[i].Collider) {
				Health -= _Amount * Hitboxes [i].DamageMultiplier;
				break;
			}
		}

		if(Health <= 0) {
			Die ();
		}

	}

	public virtual void Die() {
		Destroy (this.gameObject);
	}

}
