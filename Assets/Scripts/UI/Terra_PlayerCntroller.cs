using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terra_PlayerCntroller : MonoBehaviour
{
    public float jumpTime, jumpHeight, slideTime;

    BoxCollider2D terraCollider;
    //Box Collider size in different for different sprints. All are (0,0) offset
    private Vector2 colliderRunSize, colliderSlideSize, colliderJumpSize;

    Animator animator;
    private bool isInAction = false; //Action is state where Terra is jumping or sliding. Anything any situation when Terra should ignore player control

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        //Box Collider size in different for different sprints. All are (0,0) offset
        colliderRunSize = new Vector2(0.68f, 1.04f); 
        colliderSlideSize = new Vector2(1.16f, 0.68f);
        colliderJumpSize = new Vector2(0.57f, 1.04f);
        //get collider and set size
        terraCollider = gameObject.GetComponent<BoxCollider2D>();
        terraCollider.size = colliderRunSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInAction)
        {
            return;
        }
        //Jump
        if(Input.GetAxis("Vertical") > 0)
        {
            StartCoroutine(terraJump(jumpTime));
        }
        //Slide
        if(Input.GetAxis("Vertical") < 0)
        {
            StartCoroutine(terraSlide(slideTime));

        }
    }

    private IEnumerator terraJump(float jumpTime)
    {

        isInAction = true;
        animator.SetBool("Jump", true);
        terraCollider.size = colliderJumpSize;

        //some math with sin to getthe jumping arc

        yield return new WaitForSeconds(jumpTime);

        isInAction = false;
        terraCollider.size = colliderRunSize;
        animator.SetBool("Jump", false);

    }
    private IEnumerator terraSlide(float slideTime)
    {
        isInAction = true;
        animator.SetBool("Slide", true);
        terraCollider.size = colliderSlideSize;

        yield return new WaitForSeconds(slideTime);

        isInAction = false;
        terraCollider.size = colliderRunSize;
        animator.SetBool("Slide", false);
    }
}
