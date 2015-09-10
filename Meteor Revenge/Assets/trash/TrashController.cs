using UnityEngine;
using System.Collections;

public class TrashController : MonoBehaviour 
{
	float speed = 1f;

	Transform target;
	float targetSpeed = 0;
	Vector2 newPos;
	float newPosX = 0, newPosY = 0;

	Transform aim;
	Vector2 aimPoint;
	Vector2 dischargeTarget;
	float aimPointX = 0, aimPointY = 0;
	float shootSpeed = 0;
	bool discharged = false;

	public bool magnetedOnce, magnetedNow;

	void Awake()
	{
		GameObject.Find ("GameController").GetComponent<GameController> ().trashCount++;

		IniProps ();

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

	void IniProps()
	{
		//Escala al azar
		float scaleMultiplier = Random.Range (0.5f, 1f);

		float newScaleX = this.transform.localScale.x * scaleMultiplier;
		float newScaleY = this.transform.localScale.y * scaleMultiplier;

		Vector2 newScale = new Vector2 (newScaleX, newScaleY);

		this.transform.localScale = newScale;
	}

	void OrbitEarth	()
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

		if (targetSpeed>=5)
		{
			targetSpeed = 5;	
		}

		newPosX = Mathf.Lerp( this.transform.position.x, target.position.x, 15 / targetSpeed * Time.deltaTime); //nuevo X aproximado al iman
		newPosY = Mathf.Lerp( this.transform.position.y, target.position.y, 15 / targetSpeed * Time.deltaTime); //nueva Y aproximado al iman

		newPos = new Vector2 (newPosX, newPosY); //nueva posicion aproximada al iman

		this.transform.position = newPos; //se aproxima al iman
	}

	void ThrowTrash()
	{
		//suelta la basura y esta se dirige a donde apuntaba la nave
		if (!discharged)
		{
			discharged = true;

			aim = GameObject.FindGameObjectWithTag ("Aim").transform;

			shootSpeed = targetSpeed;
			if (shootSpeed >= 2.5f)
			{
				shootSpeed = 2.5f;
			}

			aimPoint = aim.position;
		}

		aimPointX  = Mathf.Lerp( this.transform.position.x, aimPoint.x, shootSpeed / 15 * Time.deltaTime);
		aimPointY = Mathf.Lerp( this.transform.position.y, aimPoint.y, shootSpeed / 15 * Time.deltaTime);
		
		dischargeTarget = new Vector2 (aimPointX, aimPointY);
		
		this.transform.position = dischargeTarget;
	}
}
