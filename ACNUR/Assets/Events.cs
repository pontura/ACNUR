using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
	
	public static System.Action<Vector3> OnMapClicked = delegate { };
	public static System.Action<Texture2D, string> OnNewFile = delegate { };

}

