using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScaling : MonoBehaviour
{
    public float TargetScale;
    public float TimeToReachScale;

    private float StartScale;
    private float PercentScaled;
    // Start is called before the first frame update
    void Start()
    {
        StartScale = transform.localScale.x; 
    }

    // Update is called once per frame
    void Update()
    {
        if (PercentScaled < 1f)
        {
            PercentScaled += Time.deltaTime / TimeToReachScale;

            float Scale = Mathf.Lerp(StartScale, TargetScale, PercentScaled);
            transform.localScale = new Vector3(Scale, Scale, Scale);
        }
    }
}
