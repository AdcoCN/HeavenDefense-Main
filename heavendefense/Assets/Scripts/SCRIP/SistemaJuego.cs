using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaJuego : MonoBehaviour
{
    public float duracionRondaInicial = 60f;
    private float tiempoTranscurrido = 0f;
    private int numeroRonda = 1;
    private bool rondaEnProgreso = false;
    private SistemaEconomia sistemaEconomia;

    public Text textoTiempo;
    public Text textoRonda;
    public Text textoDinero;

    void Start()
    {
        sistemaEconomia = GetComponent<SistemaEconomia>();
        IniciarNuevaRonda();
    }

    void Update()
    {
        if (rondaEnProgreso)
        {
            tiempoTranscurrido += Time.deltaTime;
            textoTiempo.text = "Tiempo: " + Mathf.Round(tiempoTranscurrido).ToString() + "s";
            textoRonda.text = "Ronda: " + numeroRonda.ToString();
            textoDinero.text = "Dinero: " + sistemaEconomia.ObtenerDinero().ToString("C2");

            if (tiempoTranscurrido >= duracionRondaInicial + (numeroRonda - 1) * 60f)
            {
                tiempoTranscurrido = 0f;
                numeroRonda++;

                if (numeroRonda <= 3)
                {
                    IniciarNuevaRonda();
                }
                else
                {
                    Debug.Log("�Juego completado!");
                }
            }
        }
    }

    void IniciarNuevaRonda()
    {
        Debug.Log("Comienza la Ronda " + numeroRonda);
        rondaEnProgreso = true;
    }
}