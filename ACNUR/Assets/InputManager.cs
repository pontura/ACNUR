using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	
	public Camera cam;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {				
			Vector3 v = cam.ScreenToWorldPoint(Input.mousePosition);
			v.z = -1;
			Events.OnMapClicked(v);
		}
	}
}
