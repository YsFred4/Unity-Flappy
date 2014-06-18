using UnityEngine;
using System.Collections;

public class ObstacleGroupScript : MonoBehaviour {

	public float obstacleSpeed = 1.0f;

	// Use this for initialization
	void Start () 
	{
		this.rigidbody2D.velocity = (-Vector2.right * obstacleSpeed);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
