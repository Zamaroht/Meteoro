using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	// Se encarga de seguir al jugador en Y
	// Limita el movimiento del jugador al area de la camara

	public float followThreshold;	// Distancia a la que tiene que estar el jugador del borde de la pantalla para que se mueva
	public GameObject playerWall;

	private Camera cam;
	private GameObject player;
	private float last_player_y, top, bottom;
	private Vector3 actual_pos;
	private bool follow;



	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		last_player_y = player.transform.position.y;

		follow = true;

		PlayerLimits ();
	}

	void Update () 
	{
		cam = GetComponent<Camera> ();

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

	void PlayerLimits()
	{
		cam = GetComponent<Camera> ();
		float cam_height = 2f * cam.orthographicSize; //obtiene altura de la camara
		float cam_width = cam_height * cam.aspect; //obtiene ancho de la camara

		Vector3 top_bot_wall_scale = new Vector3 (cam_width, 0.1f, 1f);
		Vector3 left_right_wall_scale = new Vector3 (0.1f, cam_height, 1f);

		Vector3 top_wall_pos = new Vector3 (0, cam_height / 2f, 0);
		Vector3 bot_wall_pos = new Vector3 (0, -cam_height / 2f, 0);
		Vector3 left_wall_pos = new Vector3 (cam_width / 2f, 0, 0);
		Vector3 right_wall_pos = new Vector3 (-cam_width / 2f, 0, 0);

		for (int i = 0; i < 4; i++)	//instancia las paredes invisibles (colisiona solo con el layer "player", editado desde el editor de unity); 
		{
			GameObject newPlayerWall = (GameObject) Instantiate (playerWall, Vector3.zero, Quaternion.identity);

			newPlayerWall.transform.parent = this.transform;

			switch (i) {
			case 0:
				newPlayerWall.transform.localScale = top_bot_wall_scale;
				newPlayerWall.transform.localPosition = top_wall_pos;
				newPlayerWall.name = "TopWall";
				break;
			case 1:
				newPlayerWall.transform.localScale = top_bot_wall_scale;
				newPlayerWall.transform.localPosition = bot_wall_pos;
				newPlayerWall.name = "BotWall";
				break;
			case 2:
				newPlayerWall.transform.localScale = left_right_wall_scale;
				newPlayerWall.transform.localPosition = left_wall_pos;
				newPlayerWall.name = "LeftWall";
				break;
			case 3:
				newPlayerWall.transform.localScale = left_right_wall_scale;
				newPlayerWall.transform.localPosition = right_wall_pos;
				newPlayerWall.name = "RightWall";
				break;
			default:
			break;
			}
		}
	}
}
