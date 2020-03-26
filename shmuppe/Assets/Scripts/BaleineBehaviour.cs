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
        }

        bulletCenter.GetComponent<MunitionBehaviour>().direction = new Vector2(0, -1);
        bulletRight.GetComponent<MunitionBehaviour>().direction = new Vector2(0.7f, -1);
        bulletLeft.GetComponent<MunitionBehaviour>().direction = new Vector2(-0.7f, -1);
               
    }
}
