using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Vector2 movement;

    public Animator animator;

    public Transform movePoint;

    public LayerMask obstacles;

    float horizontalMovement = 0f;
    float verticalMovement = 0f;

    void Start() {
        movePoint.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f){

            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(horizontalMovement) == 1f){
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontalMovement, 0f, 0f), .2f, obstacles)){
                    movePoint.position += new Vector3(horizontalMovement, 0f, 0f);

                    animator.SetFloat("Horizontal", horizontalMovement);
                    animator.SetFloat("Vertical", 0f);
                    animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

                    if (horizontalMovement == 1){
                        animator.SetFloat("Direction", 3);
                    }

                    else if(horizontalMovement == -1){
                        animator.SetFloat("Direction", 2);
                    }
                }
                
            }
            else if (Mathf.Abs(verticalMovement) == 1f){
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, verticalMovement, 0f), .2f, obstacles)){
                    movePoint.position += new Vector3(0f, verticalMovement, 0f);

                    animator.SetFloat("Vertical", verticalMovement);
                    animator.SetFloat("Horizontal", 0f);
                    animator.SetFloat("Speed", Mathf.Abs(verticalMovement));

                    if(verticalMovement == 1){
                        animator.SetFloat("Direction", 1);
                    }
                    else if(verticalMovement == -1){
                        animator.SetFloat("Direction", 0);
                    }
                }

                
            }
            else{
                animator.SetFloat("Horizontal", horizontalMovement);
                animator.SetFloat("Vertical", verticalMovement);
                animator.SetFloat("Speed", 0f);
            }

        }

        
        
    }


}
