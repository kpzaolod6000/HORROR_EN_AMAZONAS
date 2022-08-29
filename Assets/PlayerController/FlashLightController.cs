using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{

    //[SerializeField]
    //private GameObject flashLight;
    [SerializeField]
    private GameObject flashLightObjet;
    [SerializeField]
    private GameObject Chullachaqui;

    [SerializeField]
    private AudioSource audio_;

    [SerializeField]
    private float minBrightness = 0f;
    [SerializeField]
    private float maxBrightness = 10f;
    [SerializeField]
    private float drainRateDown = 160f;
    [SerializeField]
    private float drainRateUp = 200f;
    

    //public float maxEnergy;

    // variable singleton
    private InputManagerPlayer inputManager;

    private bool flashLightEnabled = false;
    private bool Obsoletd = false;
   
    private Transform childFlashLight;
    private Light _light;
    private ChullachaquiController scriptsTele;


    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManagerPlayer.Instance;

        childFlashLight = flashLightObjet.transform.GetChild(0);
        _light = flashLightObjet.GetComponentInChildren<Light>(); 
        Debug.Log(childFlashLight.name);

        scriptsTele = Chullachaqui.GetComponent<ChullachaquiController>();

        //

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switchFlashLight();
    }
    
    public void switchFlashLight(){
        _light.intensity = Mathf.Clamp(_light.intensity, minBrightness, maxBrightness);

        if (_light.intensity == minBrightness)
        {
            Obsoletd = true;
        }
        if (!Obsoletd)
        {
            if (inputManager.PlayerEnableFlashLight())
            {
                flashLightEnabled = !flashLightEnabled;
            }

            if (flashLightEnabled)
            {
                flashLightObjet.SetActive(true);

                if (_light.intensity > minBrightness)
                {
                    _light.intensity -= Time.deltaTime * (drainRateDown / 1000);
                }
            }
            else
            {
                flashLightObjet.SetActive(false);

                if (_light.intensity < maxBrightness)
                {
                    _light.intensity += Time.deltaTime * (drainRateUp / 1000);
                }
            }
        }
        else
        {
            _light.intensity = 0f;
            if (Chullachaqui.activeSelf == false)
            {
                Chullachaqui.SetActive(true);
                scriptsTele.enabled = true;
                audio_.Play();
            }
            if (RunSendero.activeIA)
            {
                scriptsTele.enabled = true;
                RunSendero.activeIA = false;
            }
            flashLightEnabled = false;
        }
        
        FlashLightBar.fillBar = _light.intensity;
    }
}
