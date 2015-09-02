using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	// Se encarga de seguir al jugador en Y

	public float followThreshold;	// Distancia a la que tiene que estar el jugador del borde de la pantalla para que se mueva

	private GameObject player;
	private float last_player_y, top, bottom;
	private Vector3 actual_pos;
	private bool follow;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");

		last_player_y = player.transform.position.y;

		follow = true;
	}

	void Update () 
	{
		Camera cam = GetComponent<Camera> ();

		top = cam.ScreenToWorldPoint(new Vector2(0, cam.pixelHeight)).y;
		bottom = cam.ScreenToWorldPoint(new Vector2(0, 0)).y;

		actual_pos = this.transform.position;

		if (CheckLimits())	//Controla los limites de la camara
		{
			FollowPlayer(top, bottom);
		}
	}

	void FollowPlayer (float top, float bottom)
	{
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

	bool CheckLimits()
	{
		if (actual_pos.y <= -1)	//limite inferior
		{
			follow = false;
			if (player.transform.position.y >= bottom + followThreshold)
			{
				follow = true;
			}
		}
		if (actual_pos.y >= 15)	//limite superior
		{
			follow = false;
			if (player.transform.position.y <= top - followThreshold)
			{
				follow = true;	
			}
		}

		return follow;
	}
}
