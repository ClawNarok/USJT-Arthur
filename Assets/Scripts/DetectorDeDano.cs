using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeDano : MonoBehaviour
{
    public GameObject Principal;
    [Space(20)]
    public GameObject particulaDesferirGolpe;
    public AudioClip somDesferirDano;
    ControleDeAnimacao ctrAnim;
    ControleDeAnimacaoInimigo ctrAnimIni;
    EfeitoSonoro SFX;

    void Start()
    {
        SFX = GameObject.Find("CaixaDeSom").GetComponent<EfeitoSonoro>();
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
                if (Principal.CompareTag("Enemy"))
                    return;

                if (ctrAnim.Atacando)
                    AplicaDano(other.gameObject);
                break;
        }
    }

    void AplicaDano(GameObject gbj)
    {
        gbj.transform.GetComponent<Atributos>().ReceberDano(Principal.GetComponent<Atributos>().dano);
        Instantiate(particulaDesferirGolpe, gbj.transform.position, Quaternion.identity);
        SFX.DisparoSFX(somDesferirDano, transform.position);
    }
}