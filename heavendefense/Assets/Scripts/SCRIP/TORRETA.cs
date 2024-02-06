using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public float radioDeteccion = 5f;
    public int costoTorreta = 50;
    public AudioClip sonidoDisparo;
    public GameObject prefabBala;
    public Transform puntoDisparo;
    public float cadenciaDisparo = 1f;
    public float tiempoDestruccionBala = 1.5f;
    private SistemaEconomia sistemaEconomia;
    private AudioSource audioSource;
    private float tiempoUltimoDisparo;

    void Start()
    {
        sistemaEconomia = GetComponentInParent<SistemaEconomia>();
        audioSource = GetComponent<AudioSource>();
        tiempoUltimoDisparo = -cadenciaDisparo;
    }

    void Update()
    {
        DetectarEnemigos();
    }

    void DetectarEnemigos()
    {
        Collider[] enemigosCercanos = Physics.OverlapSphere(transform.position, radioDeteccion);

        foreach (Collider enemigo in enemigosCercanos)
        {
            if (enemigo.CompareTag("Enemigo"))
            {
                Disparar(enemigo.transform.position);
            }
        }
    }

    void Disparar(Vector3 posicionEnemigo)
    {
        if (Time.time - tiempoUltimoDisparo > cadenciaDisparo)
        {
            GameObject bala = Instantiate(prefabBala, puntoDisparo.position, Quaternion.identity);
            Vector3 direccion = (posicionEnemigo - puntoDisparo.position).normalized;
            bala.GetComponent<Rigidbody>().AddForce(direccion * 10f, ForceMode.Impulse);
            tiempoUltimoDisparo = Time.time;

            if (audioSource != null && sonidoDisparo != null)
            {
                audioSource.Play();
            }

            Destroy(bala, tiempoDestruccionBala);
        }
    }
}
