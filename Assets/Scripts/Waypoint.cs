using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Direction
{
    East,
    West
}
public enum WaypoinDistance
{
    VeryClose = -1,
    Near = 0,
    InTheMiddle = 1,
    LongАway = 2
}

public class Waypoint : MonoBehaviour
{
    private List<Vector3> childsPosition;
    private const float position = 3.5f;

    public List<Vector3>  GetChildsPosition(WaypoinDistance distance, Direction direction)
    {
        childsPosition = new List<Vector3>();

        foreach (Transform child in gameObject.GetComponentInChildren<Transform>())
        {
            childsPosition.Add(new Vector3(child.position.x, child.position.y + (position * (int)distance), child.position.z));
        }

        return SortByDirection(childsPosition, direction);
    }

    private List<Vector3> SortByDirection(List<Vector3> vectors, Direction direction)
    {
        List<Vector3> sortedList = new List<Vector3>();

        switch (direction)
        {
            case Direction.East:
                sortedList = vectors.OrderBy(vector => vector.x).ToList();
                break;
            case Direction.West:
                sortedList = vectors.OrderBy(vector => -vector.x).ToList();
                break;
        }

        return sortedList;
    }
}
