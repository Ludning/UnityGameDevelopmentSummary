using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util
{
    public static class MathUtilities
    {
        public static int GetRandomInt(int max = 0)
        {
            return Random.Range(0, max);
        }
        public static bool GetRandomBool() => Random.Range(0, 2) == 1;
        public static bool GetRandomPerlinBool(float speed = 0) => Mathf.RoundToInt(Mathf.PerlinNoise(Time.time * speed, 0)) > 0.5f;
        public static float GetRandomFloat(float min = 0, float max = 1)
        {
            return Random.Range(min, max);
        }
        public static Vector2 GetRandomVector2(float min = 0, float max = 1)
        {
            return new Vector2(GetRandomFloat(min, max), GetRandomFloat(min, max));
        }

        //거리 편차 계산
        public static float Deviation(this List<float> distances)
        {
            var avarage = distances.Average();
            var sum = distances.Sum(distance => Mathf.Pow(distance - avarage, 2));
            var result = Mathf.Sqrt(sum / distances.Count);
            return result;
        }
        
        public static float GetAngle(Vector3 from, Vector3 to) => Mathf.Atan2(to.y - from.y, to.x - from.x) * Mathf.Rad2Deg;
        public static float GetAngle(Vector2 from, Vector2 to) => Mathf.Atan2(to.y - from.y, to.x - from.x) * Mathf.Rad2Deg;
        public static float GetAngle(Vector3 from, Vector3 to, Vector3 up) => Mathf.Atan2(Vector3.Dot(up, to - from), Vector3.Dot(up, from)) * Mathf.Rad2Deg;
        public static float GetAngle(Vector2 from, Vector2 to, Vector2 up) => Mathf.Atan2(Vector2.Dot(up, to - from), Vector2.Dot(up, from)) * Mathf.Rad2Deg;
        public static float GetDotProduct(Transform reference, Transform target) => Vector3.Dot(reference.forward, (target.position - reference.position).normalized);
        
        public static bool IsTargetInFront(Transform reference, Transform target)
        {
            float dotProduct = GetDotProduct(reference, target);
            return dotProduct > 0;
        }
        public static bool IsTargetInFrontWithinAngle(Transform reference, Transform target, float maxAngle)
        {
            float dotProduct = GetDotProduct(reference, target);
            float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
            return angle <= maxAngle;
        }
    }
}

