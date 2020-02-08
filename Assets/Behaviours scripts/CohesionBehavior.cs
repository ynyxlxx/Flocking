using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FilterFlockBehavior {   
    //聚合性：即群体的成员向群体成员整体的平均位置靠近，使群体的整体寻路前进效果更真实。

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        //如果附近没有neighbors的话, 原地不动
        if (context.Count == 0)
            return Vector2.zero;

        //如果存在neighbors的话，求附近所有neighbors的质心(中心点)位置
        Vector2 cohensionMove = Vector2.zero;
        List<Transform> filterContext = (contextFilter == null) ? context : contextFilter.Filter(agent, context);
        foreach (Transform item in filterContext) {
            cohensionMove += (Vector2) item.position;
        }
        cohensionMove /= context.Count;

        //计算待移动位置与现在位置之间的差值，即一个方向向量
        cohensionMove -= (Vector2)agent.transform.position;

        return cohensionMove;
    }
   
}
