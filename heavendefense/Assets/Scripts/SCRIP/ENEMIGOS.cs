using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMIGOS : MonoBehaviour
{
     Transform objetivo; // el premio
    private NavMeshAgent agente;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        objetivo = GameObject.FindGameObjectWithTag("meta").transform;
        MoverHaciaObjetivo();
    }

    void MoverHaciaObjetivo()
    {
        if (objetivo != null)
        {
            agente.SetDestination(objetivo.position);
        }   
    }
   void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("meta"));
        {
            Destroy(gameObject);
        }

    }
}

