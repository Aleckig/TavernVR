using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0.1f, 0));

        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
        
    }
}
