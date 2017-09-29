using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnPoint : MonoBehaviour {

	[SerializeField] GameObject ball;

	private Transform _transform;

	[SerializeField] private Transform _spawn;

	void Start () {
		_transform = GetComponent<Transform>();
		Instantiate(ball,_spawn.position,Quaternion.identity);

	}
	
	// Update is called once per frame

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.tag == "Goal"){
			Debug.Log("hallo");
		}
	}
	
}
