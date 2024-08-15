using UnityEngine;

namespace Roguelike.Module.Obstacle
{
    [CreateAssetMenu(fileName = "Obstacle", menuName = "ScriptableObjects/Obstacle", order = 2)]
    public class ObstacleScriptableObject : ScriptableObject
    {
        public GameObject ObstaclePrefab;
        public float DesignatedTime;
        public bool isSpawnAtPlayer;
    }
}

