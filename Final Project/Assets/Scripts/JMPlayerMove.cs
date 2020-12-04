//script based on the platformer script from class modified by Jared Mosley

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JMPlayerMove : MonoBehaviour
{
   
    public float speed = 5;
    public float jumpPower = 250;
    public Dictionary<string, GameObject> prefabDatabase;//aka hash table aka Map
    private bool canJump = false;
    Rigidbody2D rb;


    public float minYValue = -20;
    Vector3 respawnPoint;
    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }


    SpriteRenderer spriteRenderer;
    ParticleSystem pS;
    public float boxRate = .75f;
    public GameObject box;
    bool canSpawnBox = true;
    void spawnBox()
    {
        canSpawnBox = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Transform boxHoldingPos= transform.Find("boxHoldingPos");
        Debug.Log(boxHoldingPos.position);
        Debug.Log(boxHoldingPos.localPosition);
        boxHoldingPos.localPosition = new Vector3(1.5f, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            canJump = true;
        if (transform.position.y < minYValue)
        {
            transform.position = respawnPoint;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //Paige added ontriggerenter2d fucntion to destroy coins once they been collected
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject); 
        }
    }
    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        if (movement > .01f)
        {
            spriteRenderer.flipX = false;
        }
        if(movement < -.01f)
        {
            spriteRenderer.flipX = true;
        }
        if (canJump)
        {
            GameObject feet = transform.GetChild(0).gameObject;

           
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.transform.position, .25f);

            foreach (Collider2D collider in colliders)//same as for(int i = 0; i < colliders.Length; ++i)
            {
                if (collider.gameObject != gameObject)//Don't jump off ourselves
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);//ignore falling speed so we get a full jump
                    rb.AddForce(Vector2.up * jumpPower);
                    break;
                }
            }
            canJump = false;
        }

        if (canSpawnBox && (Input.GetKey(KeyCode.Q)) || (Input.GetMouseButtonDown(0)))
        {
            Instantiate(box, transform.GetChild(1).position, transform.rotation);
            canSpawnBox = false;
            Invoke("spawnBox", 1 / boxRate);
        }
    }
}
