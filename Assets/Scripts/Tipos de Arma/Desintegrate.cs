using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desintegrate : MonoBehaviour
{
    public GameObject Efeito;

    void Start()
    {
        var pos = transform.rotation;
        transform.rotation = new Quaternion(-90, pos.y, pos.z, pos.w);
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Bomba") && !col.gameObject.CompareTag("Chao"))
        {
            Instantiate(Efeito, col.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Chao"))
        {
            Instantiate(Efeito, col.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}