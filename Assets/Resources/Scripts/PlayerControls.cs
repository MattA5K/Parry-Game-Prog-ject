using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    Vector2 moveDirection;
    Vector2 lastMoveDirection;

    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    public float staminaBar = 90f;
    // int displayStamina = Mathf.RoundToInt(staminaBar);
    bool isDashing;
    bool canDash = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return;
        }
        
        //Movement
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        moveDirection = new Vector2(speedX, speedY).normalized;

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
