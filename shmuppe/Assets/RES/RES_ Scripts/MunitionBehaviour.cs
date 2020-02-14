using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D projectileRgb;
    SpriteRenderer projectileRenderer;


    void Start()
    {
        projectileRgb = GetComponent<Rigidbody2D>();
        FireBullet();
    }

    private void Update()
    {
        if (!projectileRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void FireBullet()
    {
        Debug.Log(transform.forward);
        projectileRgb.velocity = transform.up * speed; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            /// <summary>
            /// 
            ///     Add code here to deal damages to Enemy
            /// 
            /// </summary>

            Destroy(gameObject);
        }
        else if(collision.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

}
