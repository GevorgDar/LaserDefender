using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemysWave", menuName = "ScriptableObject/Enemys Wave", order = 51)]
public class EnemysWave : ScriptableObject
{
    [SerializeField] private Direction direction;
    [SerializeField] private WaypoinDistance distance;
    [SerializeField] private Waypoint waypoint;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float numberOfEnemys;
    [SerializeField] private float timeBeforeWave;

    public WaypoinDistance Distance { get { return distance; } }
    public Direction Direction { get { return direction; } }
    public Waypoint Waypoint { get { return waypoint; } }
    public GameObject Enemy { get { return enemy; } }
    public float TimeBetweenSpawns { get { return timeBetweenSpawns; } }
    public float EnemySpeed { get { return enemySpeed; } }
    public float NumberOfEnemys { get { return numberOfEnemys; } }
    public float TimeBeforeWave { get { return timeBeforeWave; } }
}
