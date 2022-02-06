using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheShooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    [SerializeField] AttackerSpawner myLaneSpawner;
    Animator animator;
    [SerializeField] float i = 0f;
    [SerializeField] float j = 0f;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME="Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            //Debug.Log("shoot pew pew");
            // TODO change animation state to shooting
            animator.SetBool("isAttacking", true);
        }
        else
        {
            //Debug.Log("sit and wait");
            // TODO change animation state to idle
            animator.SetBool("isAttacking", false);
        }
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough =
                (Mathf.Abs(spawner.transform.position.y - transform.position.y)
                < 0.5);//=Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
                i = spawner.transform.position.y;
                j = transform.position.y;
            }
        }
    }
    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Fire()
    {
        GameObject newProjectile =  Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;

    }
}
