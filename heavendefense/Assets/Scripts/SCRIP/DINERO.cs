using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DINERO : MonoBehaviour
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
        textoDinero.text = "Dinero: " + dineroActual.ToString();
    }

    public bool ComprarElemento(int costo)
    {
        if (dineroActual >= costo)
        {
            dineroActual -= costo;
            ActualizarTextoDinero();
            return true;
        }
        else
        {
            // Avisar al jugador que no tiene suficiente dinero
            return false;
        }
    }

    public void GanarDinero(int cantidad)
    {
        dineroActual += cantidad;
        ActualizarTextoDinero();
    }
}

