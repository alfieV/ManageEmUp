using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundCreation : MonoBehaviour
{
    public GameObject background;
    public Transform SpawnPoint;
    public Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = SpawnPoint.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("bg"))
        {
            Destroy(collision.gameObject);
            Instantiate(background, spawnPosition, Quaternion.identity);
        }


    }
}
