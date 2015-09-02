using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	//Controla algunos aspectos basicos

	public GameObject player;
	public bool gameStarted = false;


	void Awake () {
	
		SpawnPlayer ();

	}

	void SpawnPlayer()
	{
		GameObject newPlayer = (GameObject)Instantiate (player, Vector3.zero, Quaternion.identity);
		gameStarted = true;
	}
}
