using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBehaviour : StateMachineBehaviour
{
    /// <summary>
    /// [참고]
    /// 원래는 GetComponent Script해서 변수를 바꾸려 했으나,
    /// animator parameter로 관리하는 게 더 편할 것 같아서 이렇게 사용함.
    /// 
    /// https://forum.unity.com/threads/how-to-get-references-to-gameobjects-from-inside-a-state-machine-behaviour-script.890935/
    /// </summary>
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IS_ROLLING", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IS_ROLLING", false);
    }
}
