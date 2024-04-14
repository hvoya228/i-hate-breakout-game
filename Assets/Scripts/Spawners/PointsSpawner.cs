using System.Collections;
using System.Collections.Generic;
using Controllers.MoveControllers;
using Models;
using Pooling;
using UnityEngine;

namespace Spawners
{
    public class PointsSpawner : MonoBehaviour
    {
        [SerializeField] private List<Vector2> spawnPoints;
        [SerializeField] private GreenPoint greenPointPrefab;
        [SerializeField] private YellowPoint yellowPointPrefab;
        [SerializeField] private RedPoint redPointPrefab;
        
        private ObjectPool<GreenPoint> _greenPointsPool;
        private ObjectPool<YellowPoint> _yellowPointsPool;
        private ObjectPool<RedPoint> _redPointsPool;

        private int _lastSpawnPoint = -1;

        private void Awake()
        {
            _greenPointsPool = new ObjectPool<GreenPoint>(greenPointPrefab);
            _yellowPointsPool = new ObjectPool<YellowPoint>(yellowPointPrefab);
            _redPointsPool = new ObjectPool<RedPoint>(redPointPrefab);
        }
        
        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }
        
        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                
                var randomPoint = Random.Range(0, 3);
                var randomSpawnPoint = Random.Range(0, spawnPoints.Count);
                var randomPointSpeed = Random.Range(2f, 5f);
                
                while (randomSpawnPoint == _lastSpawnPoint)
                {
                    randomSpawnPoint = Random.Range(0, spawnPoints.Count);
                }
                
                _lastSpawnPoint = randomSpawnPoint;
                
                switch (randomPoint)
                {
                    case 0:
                        var greenPoint = GetGreenPointObject();
                        greenPoint.GetComponent<PointMover>().Speed = randomPointSpeed;
                        greenPoint.transform.position = spawnPoints[randomSpawnPoint];
                        break;
                    case 1:
                        var yellowPoint = GetYellowPointObject();
                        yellowPoint.GetComponent<PointMover>().Speed = randomPointSpeed;
                        yellowPoint.transform.position = spawnPoints[randomSpawnPoint];
                        break;
                    case 2:
                        var redPoint = GetRedPointObject();
                        redPoint.GetComponent<PointMover>().Speed = randomPointSpeed;
                        redPoint.transform.position = spawnPoints[randomSpawnPoint];
                        break;
                }
            }
        }
        
        private GreenPoint GetGreenPointObject()
        {
            var poolAble = _greenPointsPool.GetFreeObject();
            return poolAble as GreenPoint;
        }
        
        private YellowPoint GetYellowPointObject()
        {
            var poolAble = _yellowPointsPool.GetFreeObject();
            return poolAble as YellowPoint;
        }
        
        private RedPoint GetRedPointObject()
        {
            var poolAble = _redPointsPool.GetFreeObject();
            return poolAble as RedPoint;
        }
    }
}