using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : AiSpaceState
{
    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("Entered idle state");
    }

    public override void ExitState(EnemyController enemy)
    {
        Debug.Log("Exit idle state");
    }

    public override void Update(EnemyController enemy)
    {
       if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) < 10) // vertaillaan pelaajan ja enemyn etäisyyttä, jos etäisyys alle 10, vihollinen alkaa seuraamaan vihollista
        {
            enemy.ChangeState(enemy.followState);
        }

    }
}
