using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terra_PlayerCntroller : MonoBehaviour
{
    public float jumpTime, jumpHeight, slideTime;
    private float jumpTimeInRad, jumpTimeElapsed;
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
                float jumpingHeight = jumpHeight * Mathf.Sin(normalizedJumpTimeToPI);
                //apply to position
                Vector3 newLocation =  new Vector3(defaultPosition.x, defaultPosition.y + jumpingHeight, defaultPosition.z);
                transform.localPosition = newLocation;
            }
            return;
        }
        //Jump
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) )
        {
            jumpTimeElapsed = 0; //reset Jumptime elapsed from past jump
            StartCoroutine(terraJump(jumpTime));
        }
        //Slide
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) )
        {
            StartCoroutine(terraSlide(slideTime));
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
      //  terraCollider.size = colliderRunSize;
        animator.SetBool("Jump", false);

    }
    private IEnumerator terraSlide(float slideTime)
    {
        isInAction = true;
        animator.SetBool("Slide", true);
       // terraCollider.size = colliderSlideSize;

        yield return new WaitForSeconds(slideTime);

        isInAction = false;
      //  terraCollider.size = colliderRunSize;
        animator.SetBool("Slide", false);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Collide");
            FindObjectOfType<GameManager>().GameOver();
        }
    }

}
