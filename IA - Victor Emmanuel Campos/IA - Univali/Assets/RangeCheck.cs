using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCheck : MonoBehaviour
{
    [SerializeField] float seeRadius, closeRadius;
    [SerializeField] LayerMask layer;
    EntityLife myLife;
    State myState;

    private void Start()
    {
        myLife = GetComponent<EntityLife>();
        myState = GetComponent<State>();
    }

    private void Update()
    {
        if (myLife.life > 30)
        {
            if (isCloseToThePlayer()) // Se estiver proximo do player entra em combate
            {
                myState.ChangeState(state.COMBAT);
            }
            else if (isSeingThePlayer()) // Se estiver no range do player, entra em perseguição
            {
                myState.ChangeState(state.RUNOVER);
            }
        }
        else
        {
            if (isSeingThePlayer()) // Se estiver abaixo de 30 de vida, corre do player
            {
                myState.ChangeState(state.RUNOFF);
            }
        }

        if(isSeingThePlayer() == false)
        {
            myState.ChangeState(state.IDLE); // Entra em IDLE se nenhum dos anteriores estiverem ativos
        }
    }

    bool isSeingThePlayer() => Physics2D.OverlapCircle(transform.position, seeRadius, layer);
    bool isCloseToThePlayer() => Physics2D.OverlapCircle(transform.position, closeRadius, layer);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seeRadius);
        Gizmos.DrawWireSphere(transform.position, closeRadius);
    }
}
