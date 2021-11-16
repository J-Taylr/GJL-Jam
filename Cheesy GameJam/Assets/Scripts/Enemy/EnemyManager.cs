using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{


    public int health = 1;

    public float patrolSpeed = 1.0f;
    public float speed = 1.0f;
    public float RotationSpeed;
    public float knockbackStrength = 50f;
    public float startWaitTime;

    public bool Chasing = false;

    public Vector2 target;

    public Transform[] moveSpots;

    private int randomSpots;

    private float waitTime;

    private Quaternion Q;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpots = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
        if (Chasing == true)
        {
            ChasingPlayer();
        }
        if (Chasing == false)
        {
            Patrol();
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            PlayerManager pM = collision.gameObject.GetComponent<PlayerManager>();
            pM.health--;
            Debug.Log("You did one damage");

            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                Vector2 direction = collision.transform.position - transform.position;

              //  direction.y = 0;

                rb.AddForce(direction.normalized * knockbackStrength, ForceMode2D.Impulse);
                Debug.Log("Knockback");
            }

        }
    }
    void ChasingPlayer()
    {
        // move towards player
        GameObject player = GameObject.Find("Player");
        target = player.transform.position;
        Vector2 pos = gameObject.transform.position;

        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);

        // rotate towards player
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpots].position, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpots].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpots = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}

