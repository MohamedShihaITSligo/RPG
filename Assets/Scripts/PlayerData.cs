using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public float Fule, Speed, rotateSpeed;
    public double Cash;
    public int
        Health,
        Ammo,
        XP,
        Badpoints,
        GoodPoint,
        xpUntilNextLevel = 8,
        Level;
    GameManager manager;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        CheckIfLevelledUp();
    }


    void CheckIfLevelledUp()
    {
        if(XP >= (xpUntilNextLevel * Level))
        {
            Level++;
            Speed++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        if (tag.Equals("Gas"))
        {
            XP += 10;
            Fule += 10;
            Destroy(collision.gameObject);
        }
        else if (tag.Equals("Human"))
        {
            Badpoints++;
            manager.SpawnBlood(collision.transform.position);
            Destroy(collision.gameObject);
        }
        else if (tag.Equals("Zombi"))
        {
            GoodPoint++;
            XP++;
            manager.SpawnBlood(collision.transform.position);
            Destroy(collision.gameObject);
        }
    }
}
