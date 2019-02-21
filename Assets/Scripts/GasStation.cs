using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStation : MonoBehaviour {

    bool hasPlayer = false;
    PlayerData data;
    float nextFill = 0.25f;
    float elapsedTime;

    private void Update()
    {
        // if the player is in the gas station 
        if (hasPlayer)
        {
            // chck if the fule is not full and if it's time to pump fule 
            if (data.Fule < 100 && Time.time > elapsedTime)
            {
                // fill the car 
                data.Fule += 2;
                // if the fule is over FULL make it equals to Full
                if (data.Fule > 100) data.Fule = 100;
                // update the time for the next pump 
                elapsedTime = Time.time + nextFill;
                //Debug.Log("Fule: " + data.Fule);

            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player enters the station start pumping fule to the player car 
        string tag = collision.gameObject.tag;
        if ( tag.Equals("Player"))
        {
            hasPlayer = true;
            data = collision.gameObject.GetComponent<PlayerData>();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // if the player exit the station turn the pumping off
        string tag = collision.gameObject.tag;
        if (tag == "Player")
        {
            hasPlayer = false;
            elapsedTime = 0;
        }
    }
}
