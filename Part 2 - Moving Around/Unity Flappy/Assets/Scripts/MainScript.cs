using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	public int speed;
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
//		if(Input.GetKeyDown(KeyCode.Escape))
//		{
//			DestroyShip();
//		}
//		if(Input.GetKeyDown(KeyCode.R))
//		{
//			CreateShip();
//		}

		{
			ApplyForce();
		}
		if(Input.GetMouseButtonDown(0))
		{
			ApplyForce();
		}		
		if(Input.touchCount == 1)
		{
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began)
			{
				ApplyForce();
			}
		}
	}

	void ApplyForce()
	{
		if(PlayerInstance.gameObject != null)
			PlayerInstance.rigidbody2D.AddForce(Vector2.up * speed);
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
		ExplodeInstance.rigidbody2D.velocity = PlayerInstance.rigidbody2D.velocity;
		if(PlayerInstance.gameObject != null)
			DestroyObject(PlayerInstance.gameObject);
	}

}
