using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase que va a gestionar la colocación de las unidades aliadas mendiante un raycast que parte desde la
/// posición del ratón (cámara) y que lo vamos a hacer selectivo. Este rayo solo chocará con el suelo y ese
/// punto de impacto que se genera, lo usaremos para ir colocando a la unidad
/// </summary>
public class RaycastCharacter : MonoBehaviour
{
    public LayerMask groundLayer;//capa suelo, que es donde queremos colocar la unidad
    public GameObject currentObject;//el objecto(personaje) actual que quiero colocar
    public bool objectToPlace;

    Ray ray;//el rayo
    RaycastHit hit;//variable que me devuelve "el choque" entre el rayo y el gameobject


    void Update()
    {
        //Si el valor de la booleana es true
        if (objectToPlace)
        {
            //Camera.main hace referencia a la cámara de la escena que tenga la etiqueta de "MainCamera"
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //esto nos devuelve un true si el raycast está chocando con un gameobject que tenga un collider y que esté en la capa
            //suelo, si no se cumple esto me devuelve un false
            if (Physics.Raycast(ray, out hit, 100, groundLayer))
            {
                //posiciono el gameobject en el punto de impacto del raycast con el suelo
                currentObject.transform.position = hit.point;
            }

            PlaceObject();
        }
    }
    //Función para colocar el objecto en la pos que queramos
    //si ponemos objectToPlace a false dejará de ejecutar el raycast y el personaje
    //se quedará en la posición que está
    void PlaceObject()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            objectToPlace = false;
            currentObject.GetComponent<Hero>().ChangeToFinalMaterial();
            currentObject = null;
        }
    }
}
