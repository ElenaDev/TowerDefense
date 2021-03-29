using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public PlayerMovement playerMovement;//va a hacer referencia al componente PlayerMovement (el script)
    public LayerMask groundLayer;

    Ray ray;//rayo con punto de origen y dirección que uso para detectar gameobjects (tienen que tener colliders)
    RaycastHit hit;//para guardarme la información de choque entre el rayo y el gameobject

    void Start()
    {
        
    }

    void Update()
    {
        //Si pulso el botón izquierdo del ratón
        if(Input.GetMouseButtonDown(0))
        {
            //Camera.main hace referencia a la cámara de la escena que tenga la etiqueta de "MainCamera"
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //esto nos devuelve un true si el raycast está chocando con un gameobject que tenga un collider y que esté en la capa
            //suelo, si no se cumple esto me devuelve un false
            if (Physics.Raycast(ray, out hit, 100, groundLayer))
            {
                //  Debug.Log("Hit Point " + hit.point);//hit.point es el punto de impacto entre rayo y suelo (Vector3)
                playerMovement.posToGo = hit.point;
                playerMovement.Turning(hit.point);
            }
            //dibuja el rayo en el panel escena
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }
    }
}
