using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	
	public Camera cam;
	public Vector2 pos;

	void Update () {
		if(Input.GetMouseButton((0)))
			pos = cam.ScreenToWorldPoint(Input.mousePosition);
	}
}
