using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChullachaquiController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(ControllerAnimationAttack.timeNotLooking > 8)
        {
            ControllerAnimationAttack.timeNotLooking = 0;
            Spawn();
        }

        transform.LookAt(new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z));
    }

    void Spawn()
    {
        RaycastHit hit;
        float randomDistance = Random.Range(10, 20);
        float randomAngle = Random.Range(0, 360);
        Vector3 raySpawnPosition = mainCamera.transform.position + new Vector3(randomDistance * Mathf.Cos(randomAngle), 50, randomDistance * Mathf.Sin(randomAngle));

        Ray ray = new Ray(raySpawnPosition, Vector3.down);

        if( Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            if(hit.collider != null)
            {
                transform.position = hit.point;
            }
        }
    }
}
