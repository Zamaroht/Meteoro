using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	// Se encarga de los controles de la nave

	private float speed;

	void Start () 
	{
		speed = 0.15f;
	}

	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		// Controles temporales, despues los hacemos mas lindos

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) 	// Aceleracion
		{
			transform.position = transform.position + (transform.up * speed);
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 	// Rotacion izquierda
		{
			transform.Rotate(new Vector3(0, 0, 4f));
		}

		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 	// Rotacion derecha
		{
			transform.Rotate(new Vector3(0, 0, -4f));
		}

		if (Input.GetKey (KeyCode.J)) 	// Magnet
		{
			
		}

	}

}
