using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	// Se encarga de los controles de la nave

	private float minSpeed, maxSpeed, acceleration;
	private bool magnetSwitch;

	public float speed;

	void Start () 
	{
		magnetSwitch = false;
		speed = 0.0f;
		minSpeed = 1.5f;
		maxSpeed = 7.5f;
		acceleration = 1.5f;
	}

	void FixedUpdate()
	{
		MovementInput ();
		MagnetInput ();
	}

	void MovementInput()
	{
		// Controles temporales, despues los hacemos mas lindos

		transform.position = transform.position + (transform.up * speed * Time.deltaTime); // Movimiento Constante

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow))	// Aceleracion
		{
			speed = speed + (acceleration * Time.deltaTime);
		}
		else
		{ 
			speed = Mathf.Lerp(speed, minSpeed, 1f * Time.deltaTime);	// Desaceleracion
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
		if (Input.GetKeyDown (KeyCode.J))	// Magnet
		{
			this.gameObject.transform.Find ("Magnet").GetComponent<MagnetScript> ().enabled = !magnetSwitch;
			magnetSwitch = !magnetSwitch;
		}
	}
}
