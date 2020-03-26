using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MANTA : MonoBehaviour
{
    Transform ctrl;
    bool canMove = true;
    private int counter = 1;
    public float speed = 1.25f;
    public float dmg = 10;
    public bool mustMove = true;
    // Start is called before the first frame update
    void Start()
    {
        ctrl = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && counter <=11 && !mustMove)
        {
            if (transform.position == ctrl.GetChild(counter).position)
            {
                canMove = false;
                counter += 1;
                StartCoroutine(HoldUp());
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, ctrl.GetChild(counter).position, speed * Time.deltaTime);
                Debug.Log("moving");
            }
        }
        else if (mustMove)
        {
            transform.parent.Translate(new Vector3(0f, -1f,0f) * Time.deltaTime * speed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            mustMove = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthSystem>().currentHealth -= (int)dmg;
            Destroy(gameObject);
        }
    }    

    IEnumerator HoldUp()
    {
        yield return new WaitForSeconds(0.8f);
        canMove = true;

    }
}
