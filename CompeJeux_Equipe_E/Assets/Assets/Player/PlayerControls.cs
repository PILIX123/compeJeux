using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControls : MonoBehaviour
{
    bool canMove;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();

    Vector2 movementInput;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                if (!TryMove(movementInput))
                    if (!TryMove(new Vector2(movementInput.x, 0)))
                        TryMove(new Vector2(0, movementInput.y));
            }
        }
    }
    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast
            (movementInput,
            movementFilter,
            castCollision,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        return false;
    }
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
    void OnFire()
    {

    }
    public void LockMovement()
    {
        canMove = false;
    }
    public void UnlockMovement()
    {
        canMove = true;
    }
    public void SwordAttack()
    {
        LockMovement();

    }
}
