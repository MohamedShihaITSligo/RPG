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
        aliensKilled,
        GasCansCollected,
        xpUntilNextLevel = 10,
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
            XP -= xpUntilNextLevel * Level;
            Level++;
            Speed++;
        }
    }

    void AddXP(int amount)
    {
        XP += amount;
    }

    void HandelCollision(GameObject hitObject)
    {
        string tag = hitObject.tag;
        if (tag.Equals("Gas"))
        {
            GasCansCollected++;
            AddXP(10);
            //Fule += 10;
            Destroy(hitObject.gameObject);
        }
        else if (tag.Equals("Human"))
        {
            Badpoints++;
            manager.SpawnBlood(hitObject.transform.position);
            Destroy(hitObject.gameObject);
        }
        else if (tag.Equals("Alien"))
        {
            GoodPoint++;
            aliensKilled++;
            AddXP(20);
            manager.SpawnExplosion(hitObject.transform.position);
            Destroy(hitObject.gameObject);
        }
        Debug.Log("Fule: " + Fule +
            "| Aliens Count: " + 13 + "/Killd: " + aliensKilled + 
            "| Gas Cans: "+4+ "/collected: "+ GasCansCollected
            );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandelCollision(collision.gameObject);
    }
}
