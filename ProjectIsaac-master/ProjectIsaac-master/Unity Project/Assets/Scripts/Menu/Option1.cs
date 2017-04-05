using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Option1 : MenuItem {

	public override void Run_Action() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1, LoadSceneMode.Single);
	}

}
