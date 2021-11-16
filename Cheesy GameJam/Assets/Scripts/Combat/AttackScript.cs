using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Transform attackPoint;

    public GameObject projectile;

    public float attackRange = 0.5f;

    public int weapon;

    public LayerMask enemyLayer;

    EnemyManager en;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (weapon == 1))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Space) && (weapon == 2))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = 2;
        }
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            en = enemy.gameObject.GetComponent<EnemyManager>();
            en.health--;
            Debug.Log("we hit " + enemy.name);
        }
    }
    void Shoot()
    {
        Instantiate(projectile, attackPoint.transform.position, attackPoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }


}
