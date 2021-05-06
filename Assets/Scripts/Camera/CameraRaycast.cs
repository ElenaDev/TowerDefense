using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRaycast : MonoBehaviour
{
    public PlayerMovement playerMovement;//va a hacer referencia al componente PlayerMovement (el script)
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public float stoppingDistance;

    Ray ray;//rayo con punto de origen y dirección que uso para detectar gameobjects (tienen que tener colliders)
    RaycastHit hit;//para guardarme la información de choque entre el rayo y el gameobject

    void Start()
    {
        
    }

    void Update()
    {
        //Si pulso el botón izquierdo del ratón y no estoy pulsando sobre un elemento de la interfaz
        //// Check if the mouse was clicked over a UI element = !EventSystem.current.IsPointerOverGameObject()
        if (Input.GetMouseButtonDown(0) && (EventSystem.current.IsPointerOverGameObject() == false))
        {
            //Camera.main hace referencia a la cámara de la escena que tenga la etiqueta de "MainCamera"
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //si el raycast choca con un gameobject de la capa enemyLayer (es decir, si el raycast choca con un enemigo)
            if (Physics.Raycast(ray, out hit, 100, enemyLayer))
            {
                //En la llamada a la función le digo cual es la posición del enemigo
                GoToEnemy(hit.collider.transform.position);
            }
            //esto nos devuelve un true si el raycast está chocando con un gameobject que tenga un collider y que esté en la capa
            //suelo, si no se cumple esto me devuelve un false
            else if (Physics.Raycast(ray, out hit, 100, groundLayer))
            {
                GoToFloorPoint(hit.point);
            }
            
            //dibuja el rayo en el panel escena
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }
    }
    void GoToFloorPoint(Vector3 _hit)
    {
        //  Debug.Log("Hit Point " + hit.point);//hit.point es el punto de impacto entre rayo y suelo (Vector3)
        playerMovement.posToGo = _hit;
        playerMovement.Turning(_hit);
    }
    void GoToEnemy(Vector3 enemyPos)
    {
        //Vector dirección entre enemigo y player
        Vector3 dirEnemyToPlayer = playerMovement.transform.position - enemyPos;
        Vector3 posToGoPlayer = enemyPos + (dirEnemyToPlayer.normalized * stoppingDistance);
        playerMovement.attackingEnemy = true;
        playerMovement.posToGo = posToGoPlayer;
        playerMovement.Turning(enemyPos);
    }
}
