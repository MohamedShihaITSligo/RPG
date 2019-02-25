using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject blood;
	public void SpawnBlood(Vector3 position)
    {
        
        Instantiate(blood,new Vector3 (position.x,position.y,position.z+1),Quaternion.identity);
    }
}
