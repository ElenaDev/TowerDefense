using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public AllyData facu;
    public AllyData hero;
    public AllyData lich;

    public static DataManager dataManager;

    private void Awake()
    {
        dataManager = this;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
