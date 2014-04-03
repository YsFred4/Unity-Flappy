using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	public GameObject player;
	public GameObject explosion;
	private GameObject PlayerInstance;
	private GameObject ExplodeInstance;

	// Use this for initialization
	void Start () {
		CreateShip();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			DestroyShip();
		}
		if(Input.GetKeyDown(KeyCode.R))
		{
			CreateShip();
		}
	}

	void CreateShip()
	{
		if(ExplodeInstance.gameObject != null)
			DestroyObject(ExplodeInstance.gameObject);
		PlayerInstance = (GameObject)Instantiate(player);
	}

	void DestroyShip()
	{
		ExplodeInstance = (GameObject)Instantiate(explosion, PlayerInstance.transform.position, Quaternion.identity);
		DestroyObject(PlayerInstance.gameObject);
	}

}
