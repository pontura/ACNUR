using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

	public MapSlot mapSlot;
	public Transform container;
	public List<MapSlot> all;
	int total= 20;

	public MapSlot AddUser(UserData userData)
	{
		LoopRemove();
		MapSlot newMapSlot = Instantiate (mapSlot);
		newMapSlot.transform.SetParent (container);
		newMapSlot.Init (userData);
		newMapSlot.transform.localPosition = userData.coordsOrigen;
		all.Add (newMapSlot);
		return newMapSlot;
	}
	void LoopRemove()
	{
		if(all.Count>total-1)
		{
			MapSlot slotToRemove = all[0];
			Destroy(slotToRemove.gameObject);
			all.RemoveAt(0);
		}
		if(all.Count>total-1)
			LoopRemove();

	}
	public void Reset()
	{
		int i = all.Count;
		while (i > 0) {			
			i--;
			Destroy (all [i].gameObject);
		}
		all.Clear ();
	}
 
}
