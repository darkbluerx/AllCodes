using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiSpaceState //perit‰‰n muille koodeilla ominaisuudet, t‰m‰ on pohjaluokka
{// perustila basestate
    public abstract void EnterState(EnemyController enemy);

    public abstract void Update(EnemyController enemy);

    public abstract void ExitState(EnemyController enemy);

}
