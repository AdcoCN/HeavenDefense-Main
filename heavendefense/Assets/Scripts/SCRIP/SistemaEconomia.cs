using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SistemaEconomia : MonoBehaviour
{
    public int dineroInicial = 100;
    private int dineroActual;
    public TMP_Text textoDinero;

    void Start()
    {
        dineroActual = dineroInicial;
        ActualizarTextoDinero();
    }

    public void RestarDinero(int cantidad)
    {
        if (dineroActual >= cantidad)
        {
            dineroActual -= cantidad;
            ActualizarTextoDinero();
        }
        else
        {
            Debug.Log("No tienes suficiente dinero.");
        }
    }

    void ActualizarTextoDinero()
    {
        textoDinero.text = "Dinero: " + dineroActual.ToString("C2");
    }

    public bool PuedeComprar(int costo)
    {
        return dineroActual >= costo;
    }

    public void Comprar(int costo)
    {
        if (PuedeComprar(costo))
        {
            dineroActual -= costo;
            ActualizarTextoDinero();
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar esto.");
        }
    }

    public void GanarDinero(int cantidad)
    {
        dineroActual += cantidad;
        ActualizarTextoDinero();
    }

    public int ObtenerDinero()
    {
        return dineroActual;
    }
}

