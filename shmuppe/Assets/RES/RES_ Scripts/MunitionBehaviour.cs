using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 0;
    Rigidbody2D projectileRgb;
    SpriteRenderer projectileRenderer;
    [SerializeField] float lifeTime = 7;


    void Start()
    {
        projectileRgb = GetComponent<Rigidbody2D>();
        FireBullet();
        Destroy(gameObject, lifeTime);
    }

    void FireBullet()
    {
        projectileRgb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            /// <summary>
            /// 
            ///     Add code here to deal damages to Enemy
            /// 
            /// </summary>

            Destroy(gameObject);
        }
        else if (collision.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
