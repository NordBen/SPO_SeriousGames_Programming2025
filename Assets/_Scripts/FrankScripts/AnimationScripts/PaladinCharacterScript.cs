using UnityEngine;

public class PaladinCharacterScript : MonoBehaviour
{
    private Animator _Animator;
    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            _Animator.SetBool("isWalking", true);
        }
        else
        {
            _Animator.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _Animator.SetTrigger("Jump");
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _Animator.SetBool("isRunning", true);
        }
        else
        {
            _Animator.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            _Animator.SetLayerWeight(2, 1);
        }
        else
        {
            _Animator.SetLayerWeight(2, 0);
        }
    }
}
