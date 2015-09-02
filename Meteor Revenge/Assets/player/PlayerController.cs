using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	// Se encarga de los controles de la nave

	private float speed, minSpeed, maxSpeed, acceleration;

	void Start () 
	{
		speed = 0.0f;
		minSpeed = 0.015f;
		maxSpeed = 0.15f;
		acceleration = 0.15f;
	}

	void FixedUpdate()
	{
		MovementInput ();
		MagnetInput ();
	}

	void MovementInput()
	{
		// Controles temporales, despues los hacemos mas lindos

		transform.position = transform.position + (transform.up * speed); // Movimiento Constante

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow))	// Aceleracion
		{
			speed = speed + (acceleration * Time.deltaTime);
		}
		else
		{ 
			speed = speed - (acceleration * 2 *Time.deltaTime);	// Desaceleracion
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 	// Rotacion izquierda
		{
			transform.Rotate(new Vector3(0, 0, 4f));
		}
		
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 	// Rotacion derecha
		{
			transform.Rotate(new Vector3(0, 0, -4f));
		}

		if (speed <= minSpeed)	//Velocidad Maxima
		{ 
			speed = minSpeed;
		}
		if (speed >= maxSpeed)	//Velocidad Minima
		{ 
			speed = maxSpeed;
		}
	}

	void MagnetInput()
	{
		if (Input.GetKey (KeyCode.J))	// Magnet
		{
			
		}
	}
}
