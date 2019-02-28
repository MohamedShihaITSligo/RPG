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
    }

    private void FixedUpdate()
    {
        // if the player fule is more then 0 and accelerating move the car
        if (vertical!=0 && data.Fule > 0)
        {

            //this will rotat the object on the z axis
            transform.Rotate(0, 0, -(horizontal * data.rotateSpeed));
            // now move the object forward using the rigbody 2d
            // transform.up is a vector3
            body.velocity = transform.up * vertical * data.Speed;
            data.Fule -= Mathf.Abs(vertical * 0.01f);
        }
        else if(data.Fule<=0)
        {
            TeleportToNearestGasStation();
        }else body.velocity = Vector2.zero;

        body.angularVelocity = 0;
    }

    void TeleportToNearestGasStation()
    {
        float oldZPosition = transform.position.z;
        GameObject[] gasStations = GameObject.FindGameObjectsWithTag("GasStation");
        int shortestIndex = -1;
        float shortestDistance = float.MaxValue;
        for (int i = 0; i < gasStations.Length; i++)
        {
            float distance = Vector2.Distance(transform.position, gasStations[i].transform.position);
            if(distance< shortestDistance)
            {
                shortestDistance = distance;
                shortestIndex = i;
            }
        }
        //transform.position = gasStations[shortestIndex].transform.position;
        //teleport the player to the x and y gasStation and keep the z
        transform.position = new Vector3(
            gasStations[shortestIndex].transform.position.x, 
            gasStations[shortestIndex].transform.position.y,
            oldZPosition);
    }
}

