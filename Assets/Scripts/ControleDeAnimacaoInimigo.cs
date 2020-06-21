using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControleDeAnimacaoInimigo : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    public bool Atacando = false;
    public bool Morto = false;
    public GameObject particulaMorte;
    public AudioClip somMorte;
    EfeitoSonoro SFX;

    void Awake()
    {
        SFX = GameObject.Find("CaixaDeSom").GetComponent<EfeitoSonoro>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Morte()
    {
        if (Morto)
            return;

        Morto = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Atributos>().RegenVida();
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        anim.SetTrigger("Morte");
        agent.isStopped = true;
        Atacando = false;
        Morto = true;
        Instantiate(particulaMorte, transform.position, Quaternion.identity);
        SFX.DisparoSFX(somMorte, transform.position);
        var saidas = FindObjectsOfType<Saida>();
        
        for (int x = 0; x < saidas.Length; x++)
            saidas[x].AtivarSaida();

        Destroy(gameObject, 5f);
    }

    public void Venceu()
    {
        anim.SetTrigger("Venceu");
        agent.isStopped = true;
    }

    public void Move(float vel)
    {
        anim.SetFloat("Velocidade", vel);
    }

    public void Atk()
    {
        int rnd = Random.Range(1, 3);
        anim.SetInteger("Ataque", rnd);
        StartCoroutine(ResetaAtaque());
    }

    IEnumerator ResetaAtaque()
    {
        Atacando = true;
        agent.isStopped = true;
        yield return new WaitForSeconds(1f);
        agent.isStopped = false;
        anim.SetInteger("Ataque", 0);
        Atacando = false;
    }
}