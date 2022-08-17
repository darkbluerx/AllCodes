using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField]
    private Transform mainCamera;

    [SerializeField]
    private int keyCount;
 
    void Start()
    {
        
    }
  
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hitInfo, 4f))
        {
            if (hitInfo.transform.CompareTag("Door") && Input.GetKeyDown(KeyCode.E) && keyCount > 0)//avataan ovi osuessa Door tagiin ja painamalla E
            {
                hitInfo.transform.gameObject.GetComponentInParent<Animator>().SetTrigger("DoorOpen"); //avataan ovi animaattorilla
            }
            if (hitInfo.transform.CompareTag("Key") && Input.GetKeyDown(KeyCode.E))
            {
                keyCount += 1;
                Destroy(hitInfo.transform.gameObject);
            }
        }
    }
}
