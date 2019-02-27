using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour {

    GameObject Player;
    SpriteRenderer sprite;
    public float RevealDistance = 5;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        if (distance < RevealDistance) sprite.enabled = true;
        else sprite.enabled = false; 
	}
}
