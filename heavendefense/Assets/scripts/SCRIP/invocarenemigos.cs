using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class invocarenemigos : MonoBehaviour
{
    public GameObject enemigo; //se crea una variable para elegir el enemigo 
    public Terrain terreno; //se crea una variable para escoger el terreno
    public float tiempo = 0.0f; //se establece el segundo 0 
    void Start()
    { 
    }
     void Update()
    {
        tiempo += Time.deltaTime; //se establece que hay tiempo el cual esta pasando
        if (tiempo >= 1f) //se establece que al pasar x segundos ocurra algo
        {
            GameObject clone;//se guardan los clones generados con instantiate para poderlos modificar
            float tame = Random.RandomRange(3,6);//se selecciona un tamaño aleatorio usando una variable llamada tame (puede llamarse de otras formas)
            Vector3 scale = new Vector3 (tame, tame, tame); //al ser la misma variable el rango y cambio sera el mismo ej:  (10,10,10)
            float xAzar = Random.RandomRange(terreno.transform.position.x, terreno.terrainData.size.x + terreno.transform.position.x);//saca un valor aleatorio en el eje x siendo (minimo y maximo ) siendo el minimo la coordenada x a la cual le sumamos el tamaño del terreno 
            float zAzar = Random.RandomRange(terreno.transform.position.z, terreno.terrainData.size.z + terreno.transform.position.z);// lo mismo pero en el eje z
            Vector3 pos = new Vector3(xAzar, terreno.transform.position.y + 20, zAzar); //se establece el valor donde se va a crear el enemigo sacando los valores de los float anteriores y la altura siendo en este caso la posision del eje y mas 20 unidades
            clone = Instantiate(enemigo, pos, enemigo.transform.localRotation);// se usa el valor establecido para instanciar aleatoriamente al enemigo
            clone.transform.localScale = scale; //se usa el clon guardado para modificar su escala usando la variable scale creada con la variable tame, por cada instancia el tamaño cambiara es decir cada clon tendra un tamaño distinto
            tiempo = 0.0f; //se resetea el tiempo
        }
    }
}
