using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveNote : MonoBehaviour
{
    [SerializeField]
    public GameObject notVisual;

    private InputManagerPlayer inputManage;
    private bool active = false;

    // Update is called once per frame
    void Update()
    {
        inputManage = InputManagerPlayer.Instance;
        if (inputManage.PlayerTake() && active == true)
        {
            Debug.Log("cojer");
            notVisual.SetActive(true);
        }

        if (inputManage.PlayerLeave() && active == true)
        {
            Debug.Log("soltar");
            notVisual.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("collision text");
            active = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            active = false;
            notVisual.SetActive(false);
        }
    }
}
