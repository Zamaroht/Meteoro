using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	// Se encarga de seguir al jugador en Y

	public float followThreshold;	// Distancia a la que tiene que estar el jugador del borde de la pantalla para que se mueva

	private GameObject player;

	private float last_player_y;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");

		last_player_y = player.transform.position.y;
	}

	void Update () 
	{
		Camera cam = GetComponent<Camera> ();
		float top = cam.ScreenToWorldPoint(new Vector2(0, cam.pixelHeight)).y;
		float bottom = cam.ScreenToWorldPoint(new Vector2(0, 0)).y;

		if (player.transform.position.y > top - followThreshold) 
		{
			float deltay = player.transform.position.y - last_player_y;

			transform.position = new Vector3 (
				transform.position.x,
				transform.position.y + deltay,
				transform.position.z);
		} 
		else if (player.transform.position.y < bottom + followThreshold)
		{
			float deltay = player.transform.position.y - last_player_y;
			
			transform.position = new Vector3 (
				transform.position.x,
				transform.position.y + deltay,
				transform.position.z);
		} 

		last_player_y = player.transform.position.y;
	}
}
