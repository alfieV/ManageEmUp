using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAFISH : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float dmg = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,transform.position.y -1), speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthSystem>().currentHealth -= (int) dmg;
            Destroy(gameObject);
        }
    }

}
