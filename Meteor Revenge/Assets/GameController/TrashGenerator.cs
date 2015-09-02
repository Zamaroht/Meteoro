using UnityEngine;
using System.Collections;

public class TrashGenerator : MonoBehaviour {

	public GameObject trash;
	private int trashCount;

	void Awake ()
	{
		trashCount = 0;
		GenerateFirstTrash ();
	}

	void GenerateFirstTrash()
	{
		//genera la primer ola de basura espacial

		int iniTrashAmount = Random.Range (10, 21); // cantidad de basura aleatoria entre 10 y 20
		Vector3 newIniTrashPos, newIniTrashScale;

		for (int i = 0; i < iniTrashAmount; i++)
		{
			newIniTrashPos = new Vector3 (Random.Range(-7.5f, 7.5f), Random.Range(-2.5f, 17.5f), 0); // posicion aleatoria
			newIniTrashScale = new Vector3 (Random.Range(0.25f, 0.75f), Random.Range(0.25f, 0.75f), Random.Range(0.25f, 0.75f)); // escala aleatoria

			GameObject newIniTrash = (GameObject) Instantiate (trash, newIniTrashPos, Quaternion.identity);
			newIniTrash.transform.localScale = newIniTrashScale;
			newIniTrash.name = "Space Trash " + i;
			trashCount++;
		}
	}
}
