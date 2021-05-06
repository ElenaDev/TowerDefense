using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 direction;
    public int speed;
    public Material matA;
    public Material matB;
    public Renderer rend;

    void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (rend.material == matA) rend.material = matB;
            else rend.material = matA;
        }
    }
}
