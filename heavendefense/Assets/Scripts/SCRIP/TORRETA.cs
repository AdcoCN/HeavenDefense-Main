using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TORRETA : MonoBehaviour
{
    public Transform areaDeDeteccion;
    public GameObject balaPrefab;
    public GameObject bala;
    public float cooldownTime = 2f;
    private float cooldownTimer = 0f;

    void Update()
    {
        if (cooldownTimer <= 0f)
        {
            DetectarEnemigoYDisparar();
            cooldownTimer = cooldownTime;
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void DetectarEnemigoYDisparar()
    {
        // Implementa la lógica de detección de enemigos aquí
        // ...

        // Instancia una bala y ajusta su dirección
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
        bala.GetComponent<Bala>().ApuntarAlEnemigo(enemigoDetectado);
    }
}

