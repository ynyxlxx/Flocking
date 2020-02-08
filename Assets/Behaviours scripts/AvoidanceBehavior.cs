using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FilterFlockBehavior {
    //分离性：即每个群体成员需要与其他成员保持一定距离，避免重合在一起

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        //如果附近没有neighbors的话, 原地不动
        if (context.Count == 0)
            return Vector2.zero;

        Vector2 avoidanceMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filterContext = (contextFilter == null) ? context : contextFilter.Filter(agent, context);
        foreach (Transform item in filterContext) {
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SqareAvoidanceRadius) {
                nAvoid++;
                //得到远离的方向向量
                avoidanceMove += (Vector2)(agent.transform.position - item.position);
            }
        }
        if (nAvoid > 0) {
            avoidanceMove /= nAvoid;
        }

        return avoidanceMove;
    }
}
