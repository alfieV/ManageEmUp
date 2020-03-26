using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 0;
    Rigidbody2D projectileRgb;
    public Vector2 direction;
    public bool hasDirection = false;
    public bool isPlayerProjectile = true;
    public int dmg;
    [SerializeField] float lifeTime = 7;


    void Start()
    {
        projectileRgb = GetComponent<Rigidbody2D>();
        FireBullet();
        Destroy(gameObject, lifeTime);
    }

    void FireBullet()
    {
        if(hasDirection == false)
        {
            projectileRgb.velocity = transform.up * speed;
        }
        else
        {
            projectileRgb.velocity = direction * speed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (isPlayerProjectile)
        {
            if (collision.tag == "Enemy")
            {
                collision.transform.root.gameObject.GetComponent<EnemyHealthSystem>().currentHealth -= dmg;

                Destroy(gameObject);
            }
        }
        else if(!isPlayerProjectile)
        {
            if (collision.tag == "Player")
            {
                collision.transform.root.gameObject.GetComponent<PlayerHealthSystem>().currentHealth -= dmg;

                Destroy(gameObject);
            }
        }
        
        else if (collision.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
