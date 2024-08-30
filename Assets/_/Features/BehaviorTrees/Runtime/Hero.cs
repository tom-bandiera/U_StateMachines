using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTrees.Runtime
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private List<Transform> _waypoints = new List<Transform>();
        private NavMeshAgent _agent;
        private BehaviorTree _behaviorTree;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _behaviorTree = new BehaviorTree("Hero");
            _behaviorTree.AddChild(new Leaf("Patrol", new PatrolStrategy(transform, _agent, _waypoints)));
        }

        private void Update()
        {
            _behaviorTree.Process();
        }

    }

}
