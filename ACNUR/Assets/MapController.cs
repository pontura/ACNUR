using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

	public MapSlot mapSlot;
	public Transform container;
	public List<MapSlot> all;

	public void AddUser(UserData userData)
	{
		MapSlot newMapSlot = Instantiate (mapSlot);
		newMapSlot.transform.SetParent (container);
		newMapSlot.Init (userData);
		newMapSlot.transform.localPosition = userData.coordsOrigen;
		all.Add (newMapSlot);
	}
	public void Reset()
	{
		int i = all.Count;
		while (i > 0) {
			Destroy (all [i-1].gameObject);
			i--;
		}
		all.Clear ();
	}
 
}
