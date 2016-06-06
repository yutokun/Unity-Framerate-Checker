using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

	GameObject fps;

	void Start () {
		fps = GameObject.Find ("FPSCanvas");
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			fps.SetActive (!fps.activeSelf);
		}
	}
}
