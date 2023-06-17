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
        // move the player to the new position
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        // TODO check if the tile has a chance of encountering a wild pokemon
        

        // only when the player is about to reach the new tile, then we allow checking for movement inputs.
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f){


            // get the user input
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");


            // if the player moves left or right
            if (Mathf.Abs(horizontalMovement) == 1f){

                // check if there are obstacles. If there are none, allow the player to move to the tile
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontalMovement, 0f, 0f), .2f, obstacles)){

                    // update the position where the player is supposed to move.
                    movePoint.position += new Vector3(horizontalMovement, 0f, 0f);


                    // Update parameters for the animator so that animation will play
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

            // if the player moves up or down
            else if (Mathf.Abs(verticalMovement) == 1f){

                // check for obstacles. Allow movement if there are none.
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, verticalMovement, 0f), .2f, obstacles)){

                    // update the position where the player is supposed to move
                    movePoint.position += new Vector3(0f, verticalMovement, 0f);

                    // update parameters for the animator so that animation will play
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

            // if no input is detected. Set parameters for animator so idle animation is being played. 
            else{
                animator.SetFloat("Horizontal", horizontalMovement);
                animator.SetFloat("Vertical", verticalMovement);
                animator.SetFloat("Speed", 0f);
            }

        }

        
        
    }


}
