using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMIGOS : MonoBehaviour
{
    public Transform objetivo; // el premio
    private NavMeshAgent agente;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        MoverHaciaObjetivo();
    }

    void MoverHaciaObjetivo()
    {
        if (objetivo != null)
        {
            agente.SetDestination(objetivo.position);
        }
    }
}

