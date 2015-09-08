using UnityEngine;
using System.Collections;

public class TrashController : MonoBehaviour 
{
	Transform target;
	float targetSpeed;

	Vector2 newPos;
	public float speed = 1f;
	float newPosX = 0, newPosY = 0;
	public bool magnetedOnce, magnetedNow;

	void Awake()
	{
		magnetedOnce = false;
		magnetedNow = false;

		speed = 2 * (15 / (speed * (this.transform.position.y + 5))); //la velocidad es inversamente proporcional a la distancia con la Tierra
		//probar con otras ecuaciones de velocidad
	}

	void Update () 
	{
		if (!magnetedOnce && !magnetedNow) { //orbitar tierra
			OrbitEarth ();
		}
		else {
			if (magnetedOnce && magnetedNow) { //seguir al iman
				FollowMagnet();
			}
			if (magnetedOnce && !magnetedNow) { //soltar el iman
				ThrowTrash();
			}
			if (!magnetedOnce && magnetedNow) { //checkpoint para evitar errores con los booleans
				magnetedNow = false;
			}
		}
	}

	void OrbitEarth()
	{
		//si no se magnetizo, la basura "orbita" la tierra

		this.transform.Translate (Vector3.right * speed * Time.deltaTime); //se desplaza a la derecha

		if (this.transform.position.x >= 10) { //si llega al limite derecho, reinicia en la izquierda
			Vector3 resetPos = new Vector3 (-10, this.transform.position.y, 0);
			this.transform.position = resetPos;
		}
	}

	void FollowMagnet()
	{
		//persigue al iman

		target = GameObject.FindGameObjectWithTag ("Magnet").transform; //busca al iman

		targetSpeed = GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<PlayerController> ().speed;

		newPosX = Mathf.Lerp( this.transform.position.x, target.position.x, targetSpeed * Time.deltaTime); //nuevo X aproximado al iman
		newPosY = Mathf.Lerp( this.transform.position.y, target.position.y, targetSpeed * Time.deltaTime); //nueva Y aproximado al iman

		newPos = new Vector2 (newPosX, newPosY); //nueva posicion aproximada al iman

		this.transform.position = newPos; //se aproxima al iman
	}

	void ThrowTrash()
	{
		Debug.Log (this.name + " ha sido desmagnetizado");
	}
}
