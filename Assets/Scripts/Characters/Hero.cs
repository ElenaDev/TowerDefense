using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase común que tienen todos los aliado/as
/// </summary>
public class Hero : MonoBehaviour
{
    public Renderer[] renderers;
    public Material finalMaterial;
    public Material initMaterial;//material azul molón que nos indica que todavía no hemos colocado esta unidad
    public enum kindOfAlly { hero, lich};
    public kindOfAlly ally;

    private void Awake()
    {
        ChangeMaterial(initMaterial);
    }

    //función pública porque la voy a llamar desde otro script
    public void ChangeToFinalMaterial()
    {
        ChangeMaterial(finalMaterial);
    }

    //cambia el material asociado al componenten MeshRenderer
    void ChangeMaterial(Material mat)
    {
        //con un bucle for recorro el array de MeshRenderer
        for(int i=0; i < renderers.Length; i++)
        {
            //le cambio el material al componente, en la llamada a la función le especificaré
            //qué material quiero asignarle
            renderers[i].material = mat;
        }
    }

}
