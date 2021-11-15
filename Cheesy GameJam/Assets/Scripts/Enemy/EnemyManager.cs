using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    PlayerManager pM;

    public int health = 1;

    public float speed = 1.0f;
    public float RotationSpeed;
    public float knockbackStrength = 50f;

    public bool Chasing = false;

    public Vector2 target;

    private Quaternion Q;
    // Start is called before the first frame update
    void Start()
    {
     
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

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            pM = collision.gameObject.GetComponent<PlayerManager>();

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
}

