using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeDano : MonoBehaviour
{
    public GameObject Principal;
    [Space(20)]
    public GameObject particulaDesferirGolpe;
    ControleDeAnimacao ctrAnim;
    ControleDeAnimacaoInimigo ctrAnimIni;


    void Awake()
    {
        if (Principal.CompareTag("Player"))
            ctrAnim = Principal.transform.GetComponent<ControleDeAnimacao>();
        else
            ctrAnimIni = Principal.transform.GetComponent<ControleDeAnimacaoInimigo>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (ctrAnimIni.Atacando)
                    AplicaDano(other.gameObject);
                break;
            case "Enemy":
                if (ctrAnim.Atacando)
                    AplicaDano(other.gameObject);
                break;
        }
    }

    void AplicaDano(GameObject gbj)
    {
        gbj.transform.GetComponent<Atributos>().ReceberDano(Principal.GetComponent<Atributos>().dano);
        Instantiate(particulaDesferirGolpe, gbj.transform.position, Quaternion.identity);
    }
}