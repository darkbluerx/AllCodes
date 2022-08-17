using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AiSpaceState
{
    private float timer;

    public override void EnterState(EnemyController enemy) // t�ss� voitaisiin soittaa esimerkiksi ��ni
    {
        Debug.Log("Enter attack state");
    }

    public override void ExitState(EnemyController enemy)
    {
        Debug.Log("Enter attack state");
    }

    public override void Update(EnemyController enemy)
    {
        //enemy.agent.ResetPath(); // pys�ytt�� vihollisen, muut toiminnot
        enemy.transform.LookAt(new Vector3(enemy.player.transform.position.x, enemy.transform.position.y, enemy.player.transform.position.z));
        //pelaaja katsoo pelajaan suuntaan x ja z kulmassa, emme halua sen katsovan y- suunnassa, muuten vihollinen voi liikkua maahan p�in

        timer += Time.deltaTime;
        if (timer > 1)
        {
            enemy.EnemyShoot();
            timer = 0;
        }

        if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) > 10)
        {
            enemy.ChangeState(enemy.idleState);
        }
    }

}
