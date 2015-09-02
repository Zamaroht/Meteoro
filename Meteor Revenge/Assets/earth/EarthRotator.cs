using UnityEngine;
using System.Collections;

public class EarthRotator : MonoBehaviour 
{
	// "Rota" el sprite de la tierra

	private float speed;
	private Vector3 iniPos, endPos;

	void Start()
	{
		speed = 0.5f;
		iniPos = new Vector3 (-45, -5, 0);
		endPos = new Vector3 (35, -5, 0);
	}

	void Update () 
	{
		RotateEarth ();
	}

	void RotateEarth()
	{
		Vector3 actualPos = this.transform.position;

		transform.Translate (Vector3.right * speed * Time.deltaTime);	// "rotacion" de la tira

		if (actualPos.x >= endPos.x) // Si llega al limite, regresa la tira al inicio
		{
			this.transform.position = iniPos;
		}
	}
}
