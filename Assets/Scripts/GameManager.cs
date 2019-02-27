using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject blood;
    public GameObject explosion;
	public void SpawnBlood(Vector3 position)
    {
        Instantiate(blood,new Vector3 (position.x,position.y,position.z+1),Quaternion.identity);
    }
    public void SpawnBlood(Vector3 position,Color bloodColor)
    {
        GameObject splatter =Instantiate(blood,new Vector3 (position.x,position.y,position.z+1),Quaternion.identity);
        SpriteRenderer sprite = splatter.GetComponent<SpriteRenderer>();
        sprite.color = bloodColor;
    }

    public void SpawnAlienBlood(Vector3 position)
    {
        SpawnBlood(position, Color.green);
    }

    public void SpawnExplosion(Vector3 position)
    {
        Instantiate(explosion,new Vector3 (position.x,position.y,position.z+1),Quaternion.identity);
    }
}
