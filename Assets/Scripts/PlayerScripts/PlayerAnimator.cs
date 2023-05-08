using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_MOVING = "IsMoving";
    private const string IS_DEATH_DRIFTAWAY = "IsDeathByDriftAway";
    private const string IS_DEATH_CAR = "IsDeathByCar";
    private const string IS_DEATH_DROWN = "IsDeathByDrown";


    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerLife playerLife;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_DEATH_DRIFTAWAY, playerLife.deathByDriftAway);
        animator.SetBool(IS_DEATH_CAR, playerLife.deathByCar);
        animator.SetBool(IS_DEATH_DROWN, playerLife.deathByCar);

        if (playerController == null) return;
        animator.SetBool(IS_MOVING, playerController.IsMoving());
    }
}
