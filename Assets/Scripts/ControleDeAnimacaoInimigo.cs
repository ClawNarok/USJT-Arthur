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


    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Morte()
    {
        Morto = true;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        anim.SetTrigger("Morte");
        agent.isStopped = true;
        agent.enabled = false;
        Destroy(gameObject, 10f);
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