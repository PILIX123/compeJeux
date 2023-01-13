using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
public class PlayerControls : MonoBehaviour
{
    bool canMove = true;
    bool canDash = true;
    public float moveSpeed = 1f;
    public float collisionOffset = 0;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    public ShovelAttack shovelAttack;
    public ScytheAttack scytheAttack;
    public ShearsAttack shearsAttack;
    public Tilemap tools;
    public ParticleSystem LeafParticles;
    Grid grid;
    public string Tool = "";

    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();

    Vector2 movementInput;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grid = FindObjectOfType<Grid>();
        tools = GameObject.FindGameObjectWithTag("Tools").GetComponent<Tilemap>();

        animator = GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
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
                animator.SetBool("isMoving", true);
            } else
            {
                animator.SetBool("isMoving", false);
            }
            if (movementInput.x < 0)
                spriteRenderer.flipX = true;
            else if (movementInput.x > 0)
                spriteRenderer.flipX = false;
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
            rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movementInput);
            return true;
        }
        return false;
    }
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
    void OnDash()
    {
        if (canDash) {
            canDash = false;
            moveSpeed= 2f;
            animator.SetTrigger("isDashing");
        }
    }
    void StopDash()
    {
        moveSpeed = 1f;
        canDash = true;
    }
    public void LockMovement()
    {
        canMove = false;
    }
    public void UnlockMovement()
    {
        canMove = true;
    }
    void OnSelectPlant()
    {

    }
    void OnPickUp()
    {
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y);
        Vector3Int cellpos = grid.WorldToCell(playerPos);
        TileBase tile = tools.GetTile(cellpos);
        if (tile == null)
            return;
        if (tile.name == "farming-tileset_104")
            Tool = "Scythe";
        if (tile.name == "farming-tileset_105")
            Tool = "Shovel";
        if (tile.name == "shears")
            Tool = "Shears";
    }
    void OnFire()
    {
        if (Tool == "Scythe")
        {
            animator.SetTrigger("hasScythe");
        }
        if (Tool == "Shovel")
        {
            animator.SetTrigger("hasShovel");
        }
        if (Tool == "Shears")
        {
            animator.SetTrigger("hasShears");
        }
    }
    void ScytheAttack()
    {
        if(spriteRenderer.flipX == true)
        {
            scytheAttack.AttackLeft();
        }
        else
        {
            scytheAttack.AttackRight();
        }
    }
    void StopAttack()
    {
        scytheAttack.StopAttack();
        shovelAttack.StopAttack();
        shearsAttack.StopAttack();
    }
    void ShovelAttack()
    {
        if (spriteRenderer.flipX == true)
        {
            shovelAttack.AttackLeft();
        }
        else
        {
            shovelAttack.AttackRight();
        }
        
    }
    void ShearsAttack()
    {
        if (spriteRenderer.flipX == true)
        {
            shearsAttack.AttackLeft();
        }
        else
        {
            shearsAttack.AttackRight();
        }
    }
    void PlayLeafParticles()
    {
        LeafParticles.Play();
    }

}
