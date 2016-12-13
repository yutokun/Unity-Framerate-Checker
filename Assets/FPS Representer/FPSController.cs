using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSController : MonoBehaviour {

	GameObject fpsObject;
	Text text;
	int fps;

	[SerializeField, Header ("Click GameView to toggle FPS"), Tooltip ("When you use mouse button in your game, disable this checkbox.")]
	bool enableToggle;

	void Awake () {
		fpsObject = GameObject.Find ("FPSText");
		text = fpsObject.GetComponent<Text> ();
	}

	void OnEnable () {
		StartCoroutine (Count ());
	}

	void Update () {
		fps++;
		if (Input.GetMouseButtonDown (0) && enableToggle) {
			fpsObject.SetActive (!fpsObject.activeSelf);
		}
	}

	IEnumerator Count () {
		text.text = "FPS: Measuring...";
		yield return new WaitForSeconds (1);
		while (true) {
			text.text = "FPS: " + fps;
			fps = 0;
			yield return new WaitForSeconds (1);	
		}
	}
}
