using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaleineBehaviour : MonoBehaviour
{
    private Rigidbody2D baleineRgb;
    private GameObject player;
    public float speed;
    public bool isMoving;
    public GameObject bullet;
    public float timeToShoot;
    private float timer;
    private bool mustMove = true;
    public bool activePlayerTarget = true;
    public float bulletSpeed = 10;
    void Start()
    {
        baleineRgb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        timer = timeToShoot;
    }

    void FixedUpdate()
    {
        if (mustMove)
        {
            baleineRgb.velocity = new Vector2(0, -1) * speed * Time.fixedDeltaTime;
        }
        else
        {
            baleineRgb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            mustMove = false;
        }
    }

    private void Update()
    {
        if (!isMoving && timer <= 0)
        {
            Shoot();
            timer = timeToShoot;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        Vector2 playerDirection = transform.position - player.transform.position;

        if (!activePlayerTarget)
        {
            playerDirection = Vector2.zero;
        }

        List<GameObject> shootBullets = new List<GameObject>();
        var bulletCenter = Instantiate(bullet, transform.position, Quaternion.identity); ;
        var bulletLeft = Instantiate(bullet, transform.position, Quaternion.identity); ;
        var bulletRight = Instantiate(bullet, transform.position, Quaternion.identity); ;
        shootBullets.Add(bulletCenter);
        shootBullets.Add( bulletRight);
        shootBullets.Add(bulletLeft);

        for(int i = 0; i < shootBullets.Count; i++)
        {
            shootBullets[i].GetComponent<MunitionBehaviour>().hasDirection = true;
            shootBullets[i].GetComponent<MunitionBehaviour>().isPlayerProjectile = false;
            shootBullets[i].GetComponent<MunitionBehaviour>().speed = bulletSpeed;
        }

        bulletCenter.GetComponent<MunitionBehaviour>().direction = new Vector2(0, -1) + playerDirection.normalized *-1;
        bulletRight.GetComponent<MunitionBehaviour>().direction = new Vector2(0.7f, -1) + playerDirection.normalized * -1;
        bulletLeft.GetComponent<MunitionBehaviour>().direction = new Vector2(-0.7f, -1) + playerDirection.normalized * -1;
               
    }
}
