using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SistemaJuego : MonoBehaviour
{
    public float duracionRondaInicial = 60f;
    private float tiempoTranscurrido = 0f;
    private int numeroRonda = 1;
    private bool rondaEnProgreso = false;
    private SistemaEconomia sistemaEconomia;
    private SistemaColocacion sistemaColocacion;
    public TMP_Text textoTiempo;
    public TMP_Text textoRonda;
    public TMP_Text textoDinero;

    void Start()
    {
        sistemaEconomia = GetComponent<SistemaEconomia>();
        sistemaColocacion = GetComponent<SistemaColocacion>();
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

            if (Input.GetMouseButtonDown(0))  // Botón izquierdo del ratón para colocar elementos
            {
                sistemaColocacion.ColocarElemento();
            }

            if (Input.GetKeyDown(KeyCode.Y))  // Tecla Y para seleccionar torreta
            {
                sistemaColocacion.modoTorreta = true;
                sistemaColocacion.CambiarModo();
            }

            if (Input.GetKeyDown(KeyCode.G))  // Tecla G para seleccionar muro
            {
                sistemaColocacion.modoTorreta = false;
                sistemaColocacion.CambiarModo();
            }

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
                    Debug.Log("¡Juego completado!");
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
