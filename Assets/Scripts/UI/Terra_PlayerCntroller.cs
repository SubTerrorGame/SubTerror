using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terra_PlayerCntroller : MonoBehaviour
{
    public float jumpTime, jumpHeightMax, jumpHeightMin; //SlideTime deprecated since we now use hold to slide
    private float jumpTimeInRad, jumpTimeElapsed, thisJumpHeight;

    private bool jumpStarted;

    //BoxCollider terraCollider;
    //Box Collider size in different for different sprints. All are (0,0) offset
   // private Vector2 colliderRunSize, colliderSlideSize, colliderJumpSize;

    Animator animator;
    private bool isInAction = false, jumping = false; //Action is state where Terra is jumping or sliding. Anything any situation when Terra should ignore player control
    private Vector3 defaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        jumpStarted = false;
        //Box Collider size in different for different sprints. All are (0,0) offset
       // colliderRunSize = new Vector3(0.68f, 1.040f, 0.2f); 
       // colliderSlideSize = new Vector3(1.16f, 0.68f, 0.2f);
       // colliderJumpSize = new Vector3(0.57f, 1.04f, 0.2f);
        //get collider and set size
        //terraCollider = gameObject.GetComponent<BoxCollider>();
       // terraCollider.size = colliderRunSize;
        defaultPosition = transform.localPosition;
        jumpTimeInRad = Mathf.PI/jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInAction)
        {
            if(jumping)
            {
                //some math with sin to get the jumping arc
                float normalizedJumpTimeToPI = (jumpTimeElapsed) * jumpTimeInRad;
                jumpTimeElapsed += Time.deltaTime;
                float jumpingHeight = thisJumpHeight * Mathf.Sin(normalizedJumpTimeToPI);
                //apply to position
                Vector3 newLocation =  new Vector3(defaultPosition.x, defaultPosition.y + jumpingHeight, defaultPosition.z);
                transform.localPosition = newLocation;
            }
            //no longer sliding
           if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) 
            {
                isInAction = false;
                animator.SetBool("Slide", false);
            }
            return;
        }
        //Inputs
        //Jump
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) ) && !jumpStarted)
        {
            jumpStarted = true;
            return;
        }
        if(jumpStarted)
        {
            jumpTimeElapsed = 0; //reset Jumptime elapsed from past jump
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) )
            {
                thisJumpHeight = jumpHeightMax;
            }
            else
            {
                thisJumpHeight = jumpHeightMin;
            }
            StartCoroutine(terraJump(jumpTime));
        }
        
        //Slide
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
        {
            isInAction = true;
            animator.SetBool("Slide", true);
        }
        
    }

    private IEnumerator terraJump(float jumpTime)
    {

        isInAction = true;
        jumping = true;
        animator.SetBool("Jump", true);
     //   terraCollider.size = colliderJumpSize;

        yield return new WaitForSeconds(jumpTime);

        isInAction = false;
        jumping = false;
        jumpStarted = false;
      //  terraCollider.size = colliderRunSize;
        animator.SetBool("Jump", false);

    }
    /* //deprecated since we now use hold to slide
    private IEnumerator terraSlide(float slideTime)
    {
        isInAction = true;
        animator.SetBool("Slide", true);
       // terraCollider.size = colliderSlideSize;

        yield return new WaitForSeconds(slideTime);

        isInAction = false;
      //  terraCollider.size = colliderRunSize;
        animator.SetBool("Slide", false);
    }*/

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Collide");
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public bool isTerraJumping()
    {
        return jumping;
    }
}
