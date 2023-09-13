using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Vector3[] points;

    private void Awake()
    {
        points = new Vector3[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i).position;
        }
    }
}
