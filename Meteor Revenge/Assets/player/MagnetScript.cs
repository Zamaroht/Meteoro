using UnityEngine;
using System.Collections;

public class MagnetScript : MonoBehaviour
{
	//comportamiento basico para el iman
	//hacerlo sencillo y despues lo mejoramos

	GameObject[] trash;
	float trashDistance;

	float magnetRange = 1.5f;

	public bool enabled;

	void Awake()
	{
		enabled = false;

	}

	void Update()
	{
		if (enabled) {
			MagnetOn();
		}
		if (!enabled) {
			MagnetOff();
		}
	}

	void MagnetOn()
	{
		trash = GameObject.FindGameObjectsWithTag ("Trash");

		for (int i = 0; i < trash.Length; i++) {
			trashDistance = Vector3.Distance (this.transform.position, trash[i].transform.position);
			
			if (trashDistance <= magnetRange)
			{
				trash[i].GetComponent<TrashController>().magnetedOnce = true;
				trash[i].GetComponent<TrashController>().magnetedNow = true;
			}
		}
	}

	void MagnetOff()
	{
		trash = GameObject.FindGameObjectsWithTag ("Trash");

		for (int i = 0; i < trash.Length; i++) {
			if (trash[i].GetComponent<TrashController>().magnetedNow) {
				trash[i].GetComponent<TrashController>().magnetedNow = false;
			}
		}
	}
}
