using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EnemyBaseState : StateMachineBehaviour
{
    private enemy _enemy;
    public enemy getEnemyScript(Animator anim)
    {
        if(_enemy == null)
        {
          _enemy =   anim.GetComponent<enemy>();
        }
        return _enemy;
    }


}
