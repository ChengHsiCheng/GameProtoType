using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    /// <summary>
    /// 進入State
    /// </summary>
    public abstract void Enter();

    /// <summary>
    /// State中每幀執行
    /// </summary>
    public abstract void Tick(float deltaTime);

    /// <summary>
    /// 離開State
    /// </summary>
    public abstract void Exit();

    /// <summary>
    /// 計算目前攻擊動畫進度(%數)
    /// </summary>
    protected float GetNormalizedTime(Animator animator, string tagName)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        // 若在過度中, 則輸出過度後的動畫normalizedTime
        if (animator.IsInTransition(0) && nextInfo.IsTag(tagName))
        {
            return nextInfo.normalizedTime;
        }
        // 若不在過度中, 則輸出目前的動畫normalizedTime
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tagName))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0;
        }
    }

}
