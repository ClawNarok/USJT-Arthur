using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject Efeito;

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Chao") && !col.gameObject.CompareTag("Player"))
        {
            Instantiate(Efeito, transform.position + Vector3.up, Quaternion.identity);
            Destroy(gameObject);
        }
        else
            Destroy(gameObject, 1.5f);
    }
}