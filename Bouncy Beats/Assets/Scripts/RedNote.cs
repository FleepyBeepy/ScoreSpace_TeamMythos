using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedNote : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerController;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (GameManager.instance.asdfNotes[0].Find("On").gameObject.activeInHierarchy && playerController.collided) 
        {
            float distanceFromNote = Vector3.Distance(transform.position, GameManager.instance.asdfNotes[0].position);

            Debug.Log(distanceFromNote);
        }
    }

}
