using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FilterFlockBehavior {
    //对齐行动
    
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        //如果附近没有neighbors的话, 保持现有的状态
        if (context.Count == 0)
            return agent.transform.up;

        //如果存在neighbors的话，求附近所有neighbors的质心(中心点)位置
        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filterContext = (contextFilter == null) ? context : contextFilter.Filter(agent, context);
        foreach (Transform item in filterContext) {
            alignmentMove += (Vector2)item.transform.up;
        }
        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
