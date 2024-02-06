using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaEconomia : MonoBehaviour
{
    public int dineroInicial = 100;
    private int dineroActual;
    public Text textoDinero;

    void Start()
    {
        dineroActual = dineroInicial;
        ActualizarTextoDinero();
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
            // Mensaje al jugador indicando que no tiene suficiente dinero para comprar
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
