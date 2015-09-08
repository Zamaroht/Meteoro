using UnityEngine;
using System.Collections;

public class TrashController : MonoBehaviour 
{
	Transform target;
	float speed = 1;
	public bool magnetedOnce, magnetedNow;

	void Awake()
	{
		magnetedOnce = false;
		magnetedNow = false;

		speed = 15 / (speed * (this.transform.position.y + 5)); //la velocidad es inversamente proporcional a la distancia con la Tierra
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

		this.transform.Translate (Vector3.right * speed * Time.deltaTime);

		if (this.transform.position.x >= 10) {
			Vector3 resetPos = new Vector3 (-10, this.transform.position.y, 0);
			this.transform.position = resetPos;
		}
	}

	void FollowMagnet()
	{
		Debug.Log (this.name + " ha sido magnetizado");
	}

	void ThrowTrash()
	{
		Debug.Log (this.name + " ha sido desmagnetizado");
	}
}
