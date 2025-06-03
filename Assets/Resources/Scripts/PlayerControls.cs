using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    Vector2 moveDirection;
    Vector2 lastMoveDirection;



    #region PLAYERINPUT
    [SerializeField] private InputActionReference movement, pointerPosition;

    #endregion

    private Vector2 pointerInput;

    private WeaponParent weaponParent;

    #region DASH
    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    public float staminaBar = 90f;
    // int displayStamina = Mathf.RoundToInt(staminaBar);
    bool isDashing;
    bool canDash = true;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    void Start()
    {
        
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;
        
        if(isDashing)
        {
            return;
        }
        
        //Movement (OLD)
        //speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        //speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        moveDirection = movement.action.ReadValue<Vector2>();



        if (moveDirection != Vector2.zero)
        {
            lastMoveDirection = moveDirection;
        }


        #region DASH
        if (staminaBar < 90)
        {
            staminaBar = Mathf.Min(staminaBar + 10f * Time.deltaTime, 90f);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && staminaBar >= 30f)
        {
            StartCoroutine(Dash());
        }

        
        #endregion
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        staminaBar -= 30f;

        rb.velocity = new Vector2(lastMoveDirection.x * dashSpeed, lastMoveDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
       
        isDashing = false;
        canDash = true;


    }
}
