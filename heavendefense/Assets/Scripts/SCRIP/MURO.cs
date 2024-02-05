using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MURO : MonoBehaviour
{
    public float tiempoDeVida = 5f;

    void Start()
    {
        Invoke("DesaparecerValla", tiempoDeVida);
    }

    void DesaparecerValla()
    {
        Destroy(gameObject);
    }
}


