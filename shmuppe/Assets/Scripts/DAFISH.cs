using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAFISH : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,transform.position.y -1), speed * Time.deltaTime);
    }
}
