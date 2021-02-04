using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]private float speed;
    
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public Transform cam;

    // Animation...
    public Animator animator;
    private float animationSpeed = 0;


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Walk / Run speed...
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 12f;
                animationSpeed = 5f;
                //velocidadeAnim = 5f;
            }
            else
            {
                speed = 5f;
                animationSpeed = 1f;
                //velocidadeAnim = 1f;
            }

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);

            animator.SetFloat("speedAnim", animationSpeed);
        }
        else
        {
            animator.SetFloat("speedAnim", 0);
        }
    }
}
