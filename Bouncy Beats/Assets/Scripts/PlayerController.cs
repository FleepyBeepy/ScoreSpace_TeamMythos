using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
   // public PlayerController Instance = this;
    
    public bool isFastFalling = false;
    public float fastFallSpeed;
    Transform currentNote;
    void Start()
    {
        //GameManager.instance.ChangeState(GameManager.GameState.Play);
        currentNote = GameManager.instance.asdfNotes[1];
        transform.position = new Vector3(currentNote.position.x, currentNote.position.y + 5, currentNote.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Changing Notes
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            transform.position = new Vector3(GameManager.instance.asdfNotes[0].position.x, transform.position.y, transform.position.z); 
            currentNote = GameManager.instance.asdfNotes[0];
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(GameManager.instance.asdfNotes[1].position.x, transform.position.y, transform.position.z);
            currentNote = GameManager.instance.asdfNotes[1];
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(GameManager.instance.asdfNotes[2].position.x, transform.position.y, transform.position.z);
            currentNote = GameManager.instance.asdfNotes[2];
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3(GameManager.instance.asdfNotes[3].position.x, transform.position.y, transform.position.z);
            currentNote = GameManager.instance.asdfNotes[3];
        }

        //Fast Fall
        if (Input.GetMouseButtonDown(0)) 
        {
            isFastFalling = true;
            Debug.Log("Fast Falling: " + isFastFalling);
            if (transform.GetComponent<Rigidbody>().velocity.y < 0)
            {
                transform.GetComponent<Rigidbody>().velocity = new Vector3(transform.GetComponent<Rigidbody>().velocity.x, fastFallSpeed, transform.GetComponent<Rigidbody>().velocity.z);
                transform.GetComponent<SphereCollider>().material.bounciness = .4f;
            }
            else 
            {
                transform.GetComponent<Rigidbody>().velocity = new Vector3(transform.GetComponent<Rigidbody>().velocity.x, fastFallSpeed, transform.GetComponent<Rigidbody>().velocity.z);
                transform.GetComponent<SphereCollider>().material.bounciness = .4f;
            }
        }
       
        if(GetComponent<Rigidbody>().velocity.y >= 9) 
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 8, GetComponent<Rigidbody>().velocity.z);
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFastFalling == true)
        {
            isFastFalling = false;
            transform.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            transform.GetComponent<SphereCollider>().material.bounciness = .965f;
        }
        else 
        {
            transform.GetComponent<SphereCollider>().material.bounciness = .965f;
        }
        Debug.Log("Collided");

    }


}
