using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	// Se encarga de seguir al jugador en Y

	private GameObject player;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () 
	{
	
	}
}
