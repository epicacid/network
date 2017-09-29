using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _ballSpeed;
    private Rigidbody _rb;

    private Transform _transform;

     void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.right * _ballSpeed;
        _transform = GetComponent<Transform>();

    }

    void Update(){
        Vector3 clampedPos = _transform.position;
        clampedPos.x = Mathf.Clamp(_transform.position.x, -4.80f,4.0f);
        _transform.position = clampedPos;
        
    }

    float hitFactor(Vector3 _posBall,Vector3 _posRacket,float _racketHeight){ /*
    // Waar raakt het balletje het batje ? We controleren de positie van zowel het racket en de ball op de z positie aangezien dit 3d is. 
    Anders was het op de y positie.
     */

        return(_posBall.z - _posRacket.z) / _racketHeight;
        

    }

    void OnCollisionEnter(Collision coll){

        
        if(coll.gameObject.tag == "Racket1"){ // Racket 1 en Racket 2 tags dus links en rechts
          
            float z = hitFactor(transform.position,coll.transform.position,coll.collider.bounds.size.y);
            Vector3 dir = new Vector3(-1,0,z).normalized;
            GetComponent<Rigidbody>().velocity = dir * _ballSpeed;
        }
        if(coll.gameObject.tag == "Racket2"){
            float z = hitFactor(transform.position, coll.transform.position,coll.collider.bounds.size.y);
            Vector3 dir = new Vector3(1,0,z).normalized;
            GetComponent<Rigidbody>().velocity = dir * _ballSpeed;

        }
    }

}



