using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController character;
    private BoxCollider slideCollider;
    private Vector3 direction;

    public float jumpForce = 8f;
    public float gravity = 9.81f * 2f;
    public float slideTime = 1f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        slideCollider = GetComponent<BoxCollider>();
        
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        //Slide
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) 
        {
           StartCoroutine(slide(slideTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    private IEnumerator slide(float slideTime)
    {
        character.detectCollisions = false;
        yield return new WaitForSeconds(slideTime);
        character.detectCollisions = true;
    }

}