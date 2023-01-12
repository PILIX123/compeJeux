using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelAttack : MonoBehaviour
{
    public Collider2D shovelCollider;
    Vector2 rightAttackOffset;
    float damage = 5;
    // Start is called before the first frame update
    void Start()
    {
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
        if (collision.tag == "Z")
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage * 3;
            }
        }
        //neutral to tool
        if (collision.tag == "X")
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage / 2;
            }
        }
        //resist to tool
        if (collision.tag == "Y")
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage / 5 ;
            }
        }
        if (collision.tag == "DUMMY")
        {
            DUMMY d = collision.GetComponent<DUMMY>();
            if (d != null)
            {
                d.takeDamage(damage);
            }
        }
    }
}
