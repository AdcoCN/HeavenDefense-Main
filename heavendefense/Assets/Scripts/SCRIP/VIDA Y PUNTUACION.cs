using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VIDAyPUNTUACION : MonoBehaviour
{
    public int vidasIniciales = 3;
    private int vidasActuales;
    public int valorEnemigoEliminado = 10;
    public Text textoPuntuacion;

    void Start()
    {
        vidasActuales = vidasIniciales;
        ActualizarTextoPuntuacion();
    }

    void ActualizarTextoPuntuacion()
    {
        textoPuntuacion.text = "Puntuación: " + (vidasIniciales - vidasActuales) * valorEnemigoEliminado;
    }

    public void PerderVida()
    {
        vidasActuales--;

        if (vidasActuales <= 0)
        {
            // Lógica de fin de juego
            Debug.Log("Juego perdido");
        }

        ActualizarTextoPuntuacion();
    }
}

