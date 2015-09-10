using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	//Controla algunos aspectos basicos

	public GameObject player, background, earth;
	public int trashCount = 0;

	private bool gameStarted = false;
	private bool gamePaused = false;

	void Awake ()
	{
		GenerateLevel ();
		SpawnPlayer ();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) { //Pausa el juego con P o Esc
			PauseGame();
		}
	}

	void GenerateLevel()
	{
		//genera los elementos del mapa
		Vector3 newBackGroundPos = new Vector3 (0, 0, 1);
		Vector3 newEarthPos;

		GameObject newBackground = (GameObject)Instantiate (background, newBackGroundPos, Quaternion.identity); //general el fondo
		newBackground.name = "Background";

		for (int i = 0; i < 2; i++)	//genera el planeta
		{
			GameObject newEarth = (GameObject)Instantiate (earth, Vector3.zero, Quaternion.identity);
			switch (i) {
			case 0:
				newEarthPos = new Vector3 (-20, -5, 0);
				newEarth.name = "EarthA";
				newEarth.transform.position = newEarthPos;
				break;
			case 1:
				newEarthPos = new Vector3 (20, -5, 0);
				newEarth.name = "EarthB";
				newEarth.transform.position = newEarthPos;
				break;
			default:
			break;
			}
		}
	}

	void SpawnPlayer()
	{
		//spawnea al jugador en el escenario
		GameObject newPlayer = (GameObject)Instantiate (player, Vector3.zero, Quaternion.identity);
		newPlayer.name = "Player";
		gameStarted = true;
	}

	void PauseGame()
	{
		//pausa el juego
		gamePaused = !gamePaused;

		if (gamePaused) {
			Time.timeScale = 0;
		}
		else {
			Time.timeScale = 1;
		}
	}
}
