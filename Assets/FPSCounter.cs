using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {

	int fps;
	Text tx;

	void OnEnable () {
		tx = GetComponent<Text> ();
		StartCoroutine (Count ());
	}

	void Update () {
		fps++;
	}

	IEnumerator Count () {
		tx.text = "FPS: Measuring...";
		yield return new WaitForSeconds (1);
		while (true) {
			tx.text = "FPS: " + fps;
			fps = 0;
			yield return new WaitForSeconds (1);	
		}
	}
}
