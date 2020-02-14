using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float fireRate;
    float timerFireRate;

    private void Update()
    {
        if (timerFireRate <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Shoot();
            }
        }
        else
        {
            timerFireRate -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        timerFireRate = fireRate;
        Instantiate(projectile, transform.position, transform.rotation);
    }

    
}
