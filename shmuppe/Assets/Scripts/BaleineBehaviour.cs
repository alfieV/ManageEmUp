using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaleineBehaviour : MonoBehaviour
{
    private Rigidbody2D baleineRgb;
    private float playerDistance;
    public float stayDistance;
    private GameObject player;
    private Vector2 direction;
    public float speed;
    public bool isMoving;
    public GameObject bullet;
    public float timeToShoot;
    private float timer;
    void Start()
    {
        baleineRgb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        direction = new Vector2(0, 1);
        timer = timeToShoot;
    }

    void FixedUpdate()
    {
        playerDistance = transform.position.y - player.transform.position.y;

        if (Mathf.Abs(playerDistance) > stayDistance + 1)
        {
            baleineRgb.velocity = direction * speed * Time.fixedDeltaTime * -1;
        }
        else if (Mathf.Abs(playerDistance) < stayDistance - 1)
        {
            baleineRgb.velocity = direction * speed * Time.fixedDeltaTime;
        }
        else
        {
            baleineRgb.velocity = Vector2.zero;
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


        if(playerDistance > 0)
        {
            bulletCenter.GetComponent<MunitionBehaviour>().direction = new Vector2(0, -1);
            bulletRight.GetComponent<MunitionBehaviour>().direction = new Vector2(0.7f, -1);
            bulletLeft.GetComponent<MunitionBehaviour>().direction = new Vector2(-0.7f, -1);
        }
        else
        {
            bulletCenter.GetComponent<MunitionBehaviour>().direction = new Vector2(0, 1);
            bulletRight.GetComponent<MunitionBehaviour>().direction = new Vector2(0.7f, 1);
            bulletLeft.GetComponent<MunitionBehaviour>().direction = new Vector2(-0.7f, 1);
        }
        
    }
}
