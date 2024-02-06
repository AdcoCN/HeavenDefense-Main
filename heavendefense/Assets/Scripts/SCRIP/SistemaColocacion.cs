using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaColocacion : MonoBehaviour
{
    public Torreta torretaPrefab;
    public Muro muroPrefab;
    public SistemaEconomia sistemaEconomia;
    public bool modoTorreta = true;  // true para torreta, false para muro

    public void ColocarElemento()
    {
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayo, out hitInfo))
        {
            if (modoTorreta && sistemaEconomia.PuedeComprar(torretaPrefab.costoTorreta))
            {
                Torreta torretaActual = Instantiate(torretaPrefab, hitInfo.point, Quaternion.identity);
                sistemaEconomia.Comprar(torretaPrefab.costoTorreta);
            }
            else if (!modoTorreta && sistemaEconomia.PuedeComprar(muroPrefab.costoMuro))
            {
                Muro muroActual = Instantiate(muroPrefab, hitInfo.point, Quaternion.identity);
                sistemaEconomia.Comprar(muroPrefab.costoMuro);
            }
            else
            {
                Debug.Log("No tienes suficiente dinero para construir esto.");
            }
        }
    }

    public void CambiarModo()
    {
        if (modoTorreta)
        {
            Debug.Log("Modo Torreta activado");
        }
        else
        {
            Debug.Log("Modo Muro activado");
        }
    }
}
