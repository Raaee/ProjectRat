using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    [SerializeField] private StatesConditions statesConditions;
    public void StarAttack()
    {
        statesConditions.StartAttackState();
    }

    //Add extra logic that will be conected with the actual attack 
    //Reminder: take into acount that for bosses their are two types of attacks
    //BA and SP
    //Posible implementaions
    //          if / else conditioning 
    //          Another FSM for BA State and SP State
    //          Use Emun for BA State and SP State
}
