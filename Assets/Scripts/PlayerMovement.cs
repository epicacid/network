using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

	private Transform _transform;
	[SerializeField]private float _movSpeed;
	private float _vert;
	// Use this for initialization
	void Start ()
	{
		_transform = GetComponent<Transform>();
		
	}

	// Update is called once per frame
	void Update ()
	{
		if(!isLocalPlayer){
			return;
		}
		_vert = Input.GetAxisRaw("Vertical");
		_transform.position += Vector3.back * _vert * _movSpeed * Time.deltaTime;
	
		Vector3 clampedPos = _transform.position;
		clampedPos.z = Mathf.Clamp(_transform.position.z, 7.5f, 15.0f);
		_transform.position = clampedPos;
	}
}
