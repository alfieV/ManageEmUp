using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D projectileRgb;


    void Start()
    {
        projectileRgb = GetComponent<Rigidbody2D>();
        FireBullet();
        StartCoroutine(TempDestroyer());
    }

    void FireBullet()
    {
        Debug.Log(transform.forward);
        projectileRgb.velocity = transform.right * speed; 
    }


    IEnumerator TempDestroyer()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
