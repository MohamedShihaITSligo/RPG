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
    TextController text;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        text = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<TextController>();
        UpdateText();
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandelCollision(collision.gameObject);
    }

    public void UpdateText()
    {
        text.Level("Level: " + Level);
        text.Health ("Health: " + Health );
        text.Killed ("Killed: " + aliensKilled);
        text.Fule  ("Fule: " + (int)Fule);
        text.BadPoints (""+Badpoints);
        text.GoodPoints(""+GoodPoint);
    }
}
