using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SCRIPTABLE OBJECTS: DATA CONTAINERS
/// 1. La clase hereda de ScriptableObject (NO de Monobehaviour)
/// 2. Ventaja: puedes modificar los datos en runtime (con el play pulsado)
/// 3. Son serializables con JsonUtility
/// </summary>

[CreateAssetMenu(fileName = "New Ally", menuName = "Allies")]
public class AllyData : ScriptableObject
{
    public float maxHealth;
    public int speed;
    public int damage;

    public void ShowMessage()
    {
        //Do stuff
    }
}
