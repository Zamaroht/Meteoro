using UnityEngine;
using System.Collections;

public class TrashController : MonoBehaviour 
{
	float speed = 1;
	bool magnetedOnce;

	void Awake()
	{
		magnetedOnce = false;

		speed = 15 / (speed * (this.transform.position.y + 5)); //la velocidad es inversamente proporcional a la distancia con la Tierra
	}

	void Update () 
	{
		if (!magnetedOnce) {
			OrbitEarth ();
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
}
