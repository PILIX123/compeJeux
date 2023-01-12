using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelAttack : MonoBehaviour
{
    public Collider2D shovelCollider;
    Vector2 rightAttackOffset;
    // Start is called before the first frame update
    void Start()
    {
        shovelCollider = GetComponent<Collider2D>();
        rightAttackOffset= transform.localPosition;
    }
    public void AttackRight()
    {
        shovelCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }
    public void AttackLeft()
    {
        shovelCollider.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    public void StopAttack()
    {
        shovelCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //weak to tool
        if (collision.tag == "")
        {
            /*Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.health -= 5;
            }*/
        }
        //neutral to tool
        if (collision.tag == "")
        {
            /*Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.health -= 3;
            }*/
        }
        //resist to tool
        if (collision.tag == "")
        {
           /* Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.health -= 1;
            }*/
        }
    }
}
