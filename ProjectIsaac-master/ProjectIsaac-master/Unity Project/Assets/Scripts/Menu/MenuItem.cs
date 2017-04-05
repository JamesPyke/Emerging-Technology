using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class MenuItem : MonoBehaviour {

	public Image HoverImage;
	public bool Selected;

	public abstract void Run_Action();

	public virtual void Update () {
		HoverImage.enabled = Selected;
	}

	public virtual void Select() {
		Selected = true;
	}

	public virtual void Deselect() {
		Selected = false;
	}

	public virtual bool Is_Selected() {
		return Selected;
	}

}
