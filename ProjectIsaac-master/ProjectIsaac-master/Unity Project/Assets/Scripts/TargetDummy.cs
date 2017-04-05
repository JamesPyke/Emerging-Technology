using UnityEngine;
using System.Collections;

public class TargetDummy : MonoBehaviour {

	void Update() {
		GetComponent<TextMesh> ().text = transform.parent.GetComponent<TakeDamage> ().Health.ToString();		
	}

}
