using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float timer = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if(timer <= 0.0f)
        {
            Destroy(gameObject);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            EnemyManager eM = collision.gameObject.GetComponent<EnemyManager>();
            eM.health--;
        }
        Destroy(gameObject);
    }
}
