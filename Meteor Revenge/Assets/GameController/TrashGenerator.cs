using UnityEngine;
using System.Collections;

public class TrashGenerator : MonoBehaviour {

	public GameObject[] trash;

	void Awake ()
	{
		GenerateFirstTrash ();
	}

	void GenerateFirstTrash()
	{
		int iniTrashAmount = Random.Range (10, 21);

		for (int i = 0; i < iniTrashAmount; i++) {

			int r = Random.Range(0, trash.Length);
			float posY = Random.Range(-2.5f, 17.5f);

			GameObject newTrash = (GameObject) Instantiate (trash[r], new Vector3(-10, posY, 0), Quaternion.identity);
			newTrash.name = "Space Trash " + (i+1);
		}
	}
}
