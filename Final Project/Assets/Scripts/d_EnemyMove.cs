//Script by Drake Collier
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_EnemyMove : MonoBehaviour
{
    public float xRange;
    public float speed;

    private float oldPosition = 0;
    private float xPosition1 = 0;
    private float xPosition2 = 0;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = transform.position.x;
        xPosition1 = transform.position.x - xRange;
        xPosition2 = transform.position.x + xRange;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(new Vector2(xPosition1, transform.position.y), new Vector2(xPosition2, transform.position.y), Mathf.PingPong(Time.time * speed, 1.0f));

        if (transform.position.x > oldPosition)
            sprite.flipX = true;
        else
            sprite.flipX = false;

        oldPosition = transform.position.x;
    }
}
