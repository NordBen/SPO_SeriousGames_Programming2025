using UnityEngine;

public class MA2_3PAnimatedScene_Benjamin : MonoBehaviour
{
    CharacterController charController;
    [SerializeField]
    Animator _animator;
    [SerializeField] GameObject sequence;
    [SerializeField] Animation comAnim;


    [SerializeField] float moveSpeed = 5.0f;

    [SerializeField] int comboIndex = 0;
    [SerializeField] AnimationClip[] anims;
    [SerializeField] bool isAttacking = false;
    [SerializeField] bool canCombo = false;

    public bool isRagdoll = false;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        comAnim.clip = anims[comboIndex];
        comAnim.AddClip(anims[comboIndex], "anim");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            isRagdoll = !isRagdoll;
            charController.enabled = isRagdoll;
            _animator.enabled = isRagdoll;
        }

        Move();

        if (Input.GetMouseButtonDown(0))
        {/*
            if (comboIndex > 0) { return; }

            //   if (!isAttacking)
            //   {
            isAttacking = true;
            if (canCombo)
            {
                if (comboIndex >= anims.Length)
                {
                    ResetCombo();
                    return;
                }
                comboIndex++;
                canCombo = true;
            }
            else if (comboIndex == anims.Length && !canCombo)
            {
                ResetCombo();
            }
            //    }
            //_animator.Play(anims[comboIndex]);
            Debug.Log(comboIndex);*/
            comAnim.Play();
        }
    }

    void ResetCombo()
    {
        comboIndex = 0;
        canCombo = false;
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputMovement = new Vector3(horizontalInput * moveSpeed, 0, verticalInput * moveSpeed).normalized;

        _animator.SetFloat("HorizontalVelocity", inputMovement.x);
        _animator.SetFloat("VerticalVelocity", inputMovement.z);

        charController.SimpleMove(inputMovement);
        //   charController.Move(charController.velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sequencer"))
        {
            sequence.SetActive(true);
        }
    }
}
