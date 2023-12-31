using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Vector2 input;
    bool isMoving = false;

    Animator animator;

    public LayerMask obstacles;
    public LayerMask grassLayer;

    float horizontalMovement = 0f;
    float verticalMovement = 0f;

    void Start(){
        animator = GetComponent<Animator>();
    } 


    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (input.x != 0) input.y = 0;
            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                if (IsWalkable(targetPos)){
                    StartCoroutine(Move(targetPos));
                }
                
            }

        }
        animator.SetBool("isMoving", isMoving);

        
    }

    private void CheckForEncounters(){
        if (Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null){
            if (Random.Range(1,101) <= 10){
                Debug.Log("Pokemon encountered");
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;

        CheckForEncounters();
    }

    private bool IsWalkable(Vector3 targetPos){
        if (Physics2D.OverlapCircle(targetPos, 0.1f, obstacles) != null){
            return false;
        }
        return true;
    }


}
