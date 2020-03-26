using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MANTA : MonoBehaviour
{
    Transform ctrl;
    bool canMove = true;
    private int counter = 1;
    public float speed = 1.25f;
    // Start is called before the first frame update
    void Start()
    {
        ctrl = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && counter <=11)
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

    }

    IEnumerator HoldUp()
    {
        yield return new WaitForSeconds(0.8f);
        canMove = true;

    }
}
