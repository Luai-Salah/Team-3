using UnityEngine;

public class Plr_Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public float jumpHight = 3f;

    public float gravity = -9.18f;
    public float groundDis = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    void LateUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDis, groundMask);

		if (isGrounded && velocity.y < 0)
		{
            velocity.y = -2f;
		}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
            velocity.y = Mathf.Sqrt(jumpHight * -2 * gravity);
		}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
