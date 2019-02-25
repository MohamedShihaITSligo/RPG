using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    
    
    float horizontal, vertical;
    Rigidbody2D body;
    PlayerData data;
    

    void Start () {
        body = GetComponent<Rigidbody2D>();
        data = GetComponent<PlayerData>();

    }
	
	
	void Update () {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");


        /*  
         *  2 ways to rotat an object
         *  ------------------------------------------------------------
         *  #1
         *  NOTE!!! 
         *  -------
         *  first set the rotat speed to an angle of 
         *  maybe 180 for the turn speed 
         *  #2
         *  using the rotat method in transform class
         *  ------------------------------------------------------------------
         */
         
        // if the player fule is more then 0 and accelerating move the car
        if (vertical != 0 && data.Fule>0)
        {
            //#1
            //this will rotat the object on the z axis
            transform.Rotate(0, 0, -(horizontal * data.rotateSpeed));
            // now move the object forward using the rigbody 2d
            // transform.up is a vector3
            body.velocity = transform.up * vertical * data.Speed;
            data.Fule -= Mathf.Abs(vertical * 0.01f);
            //#2
            ////get the z angle
            //float z = transform.eulerAngles.z;
            //z -= horizontal * rotateSpeed * Time.deltaTime;
            //// feed the z to the rotation
            //transform.rotation = Quaternion.Euler(0, 0, z);
            //// move the car
            //transform.position += transform.rotation * (new Vector3( 0, vertical * speed * Time.deltaTime, 0) );

        }
        else
        {
            body.velocity = new Vector3(0, 0, 0);
        }
    }
}
