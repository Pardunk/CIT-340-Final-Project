//script based on the platformer script from class modified by Jared Mosley

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JMPlayerMove : MonoBehaviour
{
   
    public float speed = 5;
    public float jumpPower = 250;
    private bool canJump = false;
    [HideInInspector]public bool canMove = true;
    Rigidbody2D rb;
    AudioSource jumpSound;
    AudioSource coinSnd;
    public float minYValue = -20;
    Vector3 respawnPoint;
    Animator anim;
    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    //Added by Drake Collier
    public void Respawn()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        //Get rid of all boxes spawned on respawn
        for (var i = 0; i < boxes.Length; ++i)
            Destroy(boxes[i]);

        transform.position = respawnPoint;
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
        SetRespawnPoint(transform.position);
        canMove = true;
        anim = GetComponent<Animator>();
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
            coinSnd = other.gameObject.GetComponent<AudioSource>();//audio scripting added by Jared M
            coinSnd.Play();
            Destroy(other.gameObject); 
        }
    }
    void FixedUpdate()
    {

        jumpSound = GetComponent<AudioSource>();

        //Added by Drake:
        //Checks if the player can move
        //This is necessary for disabling movement when a level is beaten
        if (canMove)
        {
            float movement = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            if (movement > .01f)
            {
                spriteRenderer.flipX = false;
                Transform boxHoldingPos= transform.Find("boxHoldingPos");
                boxHoldingPos.localPosition = new Vector3(1.5f, 0, 0);
            }
            if (movement < -.01f)
            {
                spriteRenderer.flipX = true;
                Transform boxHoldingPos = transform.Find("boxHoldingPos");
                boxHoldingPos.localPosition = new Vector3(-1.5f, 0, 0);
            }
            if (Mathf.Abs(movement) > .01f)
            {
                anim.SetBool("isWalking", true);
            }
            else
                anim.SetBool("isWalking", false);

        }

        if (canJump)
        {
            jumpSound.Play();
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
