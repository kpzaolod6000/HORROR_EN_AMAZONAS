using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightBar : MonoBehaviour
{
    private RectTransform maskFlashLight;
    public static float fillBar { get; set; }

    private float maxMaskV = 130f;
    private float maxIntesity = 10f;
    private float minMaskV = 0f;
    // Start is called before the first frame update
    void Start()
    {
        maskFlashLight = GetComponent<RectTransform>();
        maskFlashLight.sizeDelta = new Vector2(maxMaskV, 5.999986f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fillBar = (fillBar * maxMaskV) / maxIntesity;        
        maskFlashLight.sizeDelta = new Vector2(fillBar, 5.999986f);
    }
}
