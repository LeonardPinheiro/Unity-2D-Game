using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public string GoToScene = "HomeScene";

    PlayerInputs inputActions;

    public float speed = 2.7f;
    public float jumpForce = 5f;

    public GameObject shootPrefab;
    public float shootForce = 10f;

    bool canJump = true;
    bool canAttack = true;

    SpriteRenderer sprit;
    Animator animator;
    Rigidbody2D body;




    // Start is called before the first frame update
    private void Start()
    {
        sprit = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        inputActions = new PlayerInputs();

    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        var MoveInput = inputActions.PlayerMap.Movement.ReadValue<Vector2>();

        transform.position += speed * Time.deltaTime * new Vector3(MoveInput.x, 0, 0);

        animator.SetBool("b_isWalk", MoveInput.x != 0);

        if (MoveInput.x != 0)
        {
            sprit.flipX = MoveInput.x <0;
        }

        canJump = Mathf.Abs(body.velocity.y) <= 0.001f;

        HandleJumpAnim();

        HandleAttack();

        HandleRestart();

    }

    void HandleJumpAnim(){

       var JumpPress = inputActions.PlayerMap.Jump.IsPressed();

            if (canJump && JumpPress){

                body.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);

            }

    }

    void HandleAttack()
    {
        var AttackIsPress = inputActions.PlayerMap.Attack.IsPressed();

        if (canAttack && AttackIsPress) 
        { 
            canAttack = false;

            animator.SetTrigger("t_Attack");

        }
    }
    public void shotNewEgg() 
    {
        var newShoot = GameObject.Instantiate(shootPrefab);
        newShoot.transform.position = transform.position;

        var isLookRight = !sprit.flipX;
        Vector2 shotDirection = shootForce * new Vector2(isLookRight ? -1 : 1, 0);
        newShoot.GetComponent<Rigidbody2D>().AddForce(shotDirection, ForceMode2D.Impulse);
        newShoot.GetComponent<SpriteRenderer>().flipY = !isLookRight;
    }
    public void setCanAttack()
    {
        canAttack = true;
    }

    public void HandleRestart()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene(GoToScene);
        }
    }
}
