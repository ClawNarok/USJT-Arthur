using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    /*
    criar 8 dipos de disparo para o personagem
    exemplo: explode, incolhe, aumenta, implode, desaparece
    */
    public GameObject[] projetilPrefab;
    public int projetilIndice = 0;


    void Update()
    {
        float movx = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3 (-movx, 0, 0));

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject myprojectile = Instantiate(projetilPrefab[projetilIndice], transform.position + transform.forward - transform.up, Quaternion.identity);
            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        }

        projetilIndice -= (int)Input.mouseScrollDelta.y;
        if (projetilIndice >= projetilPrefab.Length)
            projetilIndice = 0;
        if (projetilIndice < 0)
            projetilIndice = projetilPrefab.Length - 1;
    }
}