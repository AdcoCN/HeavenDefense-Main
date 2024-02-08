using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class Muro : MonoBehaviour
{
    public float tiempoVisible = 6f;
    private float tiempoTranscurrido = 0f;
    public int costoMuro = 40;
    public SistemaEconomia sistemaEconomia;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DesactivarMuro", tiempoVisible);
    }

    // Update is called once per frame
    void DesactivarMuro()
    {
        gameObject.SetActive(false);
        if(sistemaEconomia !=null) 
        {
            sistemaEconomia.RestarDinero(costoMuro);
        }
    }
}
