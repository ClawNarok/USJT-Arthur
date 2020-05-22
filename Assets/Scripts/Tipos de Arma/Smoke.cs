using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public GameObject Efeito;

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Bomba"))
        {
            Destroy(gameObject);
            Instantiate(Efeito, transform.position, Quaternion.identity);
        }
    }
}