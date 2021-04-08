using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SCRIPTABLE OBJECTS: DATA CONTAINERS
/// 1. La clase hereda de ScriptableObject (NO de Monobehaviour)
/// 2. Ventaja: puedes modificar los datos en runtime (con el play pulsado)
/// 3. Son serializables con JsonUtility
/// </summary>

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies")]
public class EnemyData : ScriptableObject
{
    public string nameEnemy;
    public Sprite image;
    public float maxHealth;
    public float force;
    public int speed;

    public void ShowMessage()
    {
        Debug.Log("My name is " + nameEnemy);
    }
}
