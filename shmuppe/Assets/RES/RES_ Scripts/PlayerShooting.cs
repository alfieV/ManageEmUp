using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] float fireRate = 1;
    float timerFireRate;

    private void Update()
    {
        if (timerFireRate <= 0)
        {
            if (Input.GetKey(KeyCode.Space) && GameManager.Instance.inputEnable)
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
