using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovements : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    
    

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.y += speed * Time.deltaTime;
        transform.position = position;

    }
}
