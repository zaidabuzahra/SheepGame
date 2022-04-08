using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float TimeToDistroy;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeToDistroy);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
