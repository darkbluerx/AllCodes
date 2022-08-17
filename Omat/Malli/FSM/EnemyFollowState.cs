using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyFollowState : AiSpaceState
{
   
    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("Entered follow state");
    }

    public override void ExitState(EnemyController enemy)
    {
        Debug.Log("Exit follow state");
    }

    public override void Update(EnemyController enemy)
    {
        enemy.agent.SetDestination(enemy.player.transform.position);
        enemy.SetAudio();
;
        if(Vector3.Distance(enemy.transform.position, enemy.player.transform.position) > 11)
        {
            enemy.ChangeState(enemy.idleState);
        }

        if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) > 6)
        {
            enemy.ChangeState(enemy.attackState);
        }
    }
}