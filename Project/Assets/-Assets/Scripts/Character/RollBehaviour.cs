using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBehaviour : StateMachineBehaviour
{
    /// <summary>
    /// [����]
    /// ������ GetComponent Script�ؼ� ������ �ٲٷ� ������,
    /// animator parameter�� �����ϴ� �� �� ���� �� ���Ƽ� �̷��� �����.
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
