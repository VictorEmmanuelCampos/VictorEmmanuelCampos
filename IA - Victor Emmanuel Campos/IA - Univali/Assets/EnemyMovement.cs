using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Codigo que fala se o inimigo vai estar em estado de IDLE, RUNOVER, COMBAT ou RUNOFF
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Transform playerPosition;
    float currentSpeed;
    State myState;

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        myState = GetComponent<State>();
        currentSpeed = moveSpeed;       
    }

    private void FixedUpdate()
    {
        SetCurrentSpeed();
        Move();
    }

    void SetCurrentSpeed()
    {
        switch (myState.GetEntetyState())
        {
            case state.IDLE:
                currentSpeed = 0;
                break;
            case state.RUNOVER:
                currentSpeed = moveSpeed;
                break;
            case state.COMBAT:
                currentSpeed = 0;
                break;
            case state.RUNOFF:
                currentSpeed = -moveSpeed;
                break;
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, currentSpeed);
    }
}
