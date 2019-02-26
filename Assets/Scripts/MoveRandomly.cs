using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour
{
    public int speed;
    Vector2 direction;
    Rigidbody2D body;


    void Start()
    {
        speed = 8;
        body = gameObject.GetComponent<Rigidbody2D>();
        Move();
    }

    void Move()
    {
        int leftOrRight = Random.Range(-1, 2);
        if (leftOrRight == 0) leftOrRight = -1;
        direction.x = Random.Range(-120, 120);
        direction.y = Random.Range(-120, 120);
        direction.Normalize();
        body.velocity = direction * speed * leftOrRight;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Barrier"))
            body.velocity = body.velocity * -1;
           // Move();
    }
}
