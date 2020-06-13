using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoIA : MonoBehaviour
{
    public GameObject Alvo;
    public NavMeshAgent agent;
    public EstadoIA estadoAtual;

    public enum EstadoIA
    {
        Andando,
        Atacando
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agent.isStopped)
            estadoAtual = EstadoIA.Atacando;
        else
            estadoAtual = EstadoIA.Andando;
    }
}