using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Stay In Radius")]
public class StayInRadiusBehaviors : FlockBehavior {
    public Vector2 center;
    public float radius = 15f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        //agent到圆心的方向向量
        Vector2 centreOffset = center - (Vector2) agent.transform.position;
        float distanceRatio = centreOffset.magnitude / radius;

        if (distanceRatio < 0.9f) {
            return Vector2.zero;
        }

        return centreOffset * distanceRatio * distanceRatio;
    }
}
