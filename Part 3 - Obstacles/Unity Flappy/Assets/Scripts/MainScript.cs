using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	public int speed;
	public GameObject player;
	public GameObject explosion;
	private GameObject PlayerInstance;
	private GameObject ExplodeInstance;

	public GameObject obstacle;
	public Transform obstacleStart;

	private float firstObstacleDelay = 1.0f;
	private float obstacleSeparationDelay = 4.0f;
	private float obstacleDestroyDelay = 10.0f;


	// Use this for initialization
	void Start () {
		CreateShip();
		Invoke("MakeObstacle", firstObstacleDelay);
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

		if(Input.GetKeyDown(KeyCode.Space))
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

	private Random rand = new Random();
	void MakeObstacle()
	{
		Transform pos = obstacleStart;
		pos.position = new Vector3(obstacleStart.position.x,Random.Range(-2.5f,2.5f),obstacleStart.position.z);
		GameObject p = (GameObject)Instantiate(obstacle, pos.position, Quaternion.identity);
		Destroy((GameObject)p, obstacleDestroyDelay);
		Invoke("MakeObstacle", obstacleSeparationDelay);	
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
