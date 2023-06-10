using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float jumpForce = 8f;
    public float gravity = 9.81f * 2f;
    //public float slideTime = 1f; //deprecated since we now use hold to slide

    private bool isSliding = false;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        //Slide
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
        {
           isSliding = true;
        }
        //no longer sliding
        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) 
        {
           isSliding = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.CompareTag("Stalactite") && !isSliding){
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    /* //deprecated since we now use hold to slide
    private IEnumerator slide(float slideTime)
    {
        isSliding = true;
        yield return new WaitForSeconds(slideTime);
        isSliding = false;
    }*/

}