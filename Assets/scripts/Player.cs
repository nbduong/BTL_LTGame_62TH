using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 30.0f;
    private Rigidbody rb;
    public Vector3 moveInput;
    public Animator animator;
    public float rollBoost = 20f;
    private float rollTime;
    public float RollTime;
    bool rollOne = false;
    public SpriteRenderer charaterSR;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * speed * Time.deltaTime;
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        
        if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            animator.SetBool("roll", true);
            speed += rollBoost;
            rollTime = RollTime;
            rollOne = true;
        }

        if (rollTime <= 0 && rollOne == true)
        {
            animator.SetBool("roll", false);
            speed -= rollBoost;
            rollOne = false;
        }else
        {
            rollTime -= Time.deltaTime;
        }

        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
            {
                charaterSR.transform.localScale = new Vector3(1, 1, 0);
            }
            else
            {
                charaterSR.transform.localScale = new Vector3(-1, 1, 0);
            }
            
        }
    }
}
