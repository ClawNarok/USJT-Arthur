using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooter : MonoBehaviour
{
    /*
    criar 8 dipos de disparo para o personagem
    exemplo: explode, incolhe, aumenta, implode, desaparece
    */
    public GameObject[] projetilPrefab;
    public int projetilIndice = 0;
    public Text txtArma;

    void Awake()
    {
        if (!txtArma)
        {
            txtArma = GameObject.Find("Armas").GetComponent<Text>();
            txtArma.text = string.Concat("Arma: ", projetilIndice + 1, "/", projetilPrefab.Length);
        }
    }

    void Update()
    {
        float movx = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3 (-movx, 0, 0));

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject myprojectile = Instantiate(projetilPrefab[projetilIndice], transform.position + transform.forward - transform.up, Quaternion.identity);
            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            projetilIndice -= (int)Input.mouseScrollDelta.y;

            if (projetilIndice >= projetilPrefab.Length)
                projetilIndice = 0;

            if (projetilIndice < 0)
                projetilIndice = projetilPrefab.Length - 1;

            txtArma.text = string.Concat("Arma: ", projetilIndice + 1, "/", projetilPrefab.Length);
        }
    }
}