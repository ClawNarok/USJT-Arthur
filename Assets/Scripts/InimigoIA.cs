using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoIA : MonoBehaviour
{
    public GameObject Alvo;
    public NavMeshAgent agent;
    public EstadoIA estadoAtual;
    ControleDeAnimacaoInimigo ctrAnim;

    public enum EstadoIA
    {
        Andando,
        Atacando
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ctrAnim = GetComponent<ControleDeAnimacaoInimigo>();
    }

    void Update()
    {
        if (ctrAnim.Morto)
            return;
        if ((MovePlayer.posPlayer - transform.position).magnitude <= agent.stoppingDistance)
            estadoAtual = EstadoIA.Atacando;
        else
            estadoAtual = EstadoIA.Andando;

        switch (estadoAtual)
        {
            case EstadoIA.Andando:
                agent.SetDestination(MovePlayer.posPlayer);
                ctrAnim.Move(agent.velocity.magnitude);
                break;
            case EstadoIA.Atacando:
                if (!ctrAnim.Atacando)
                    ctrAnim.Atk();
                break;
        }


    }
}