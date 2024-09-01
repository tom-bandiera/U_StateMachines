using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTrees.Runtime
{
    public class Hero : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private BehaviorTree _behaviorTree;
        [SerializeField] private List<Transform> _waypoints = new List<Transform>();
        [SerializeField] private GameObject _treasure;
        [SerializeField] private GameObject _box;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _behaviorTree = new BehaviorTree("Hero");
            // _behaviorTree.AddChild(new Leaf("Patrol", new PatrolStrategy(transform, _agent, _waypoints)));

            Leaf isTreasurePresent = new Leaf("IsTreasurePresent", new ConditionStrategy(() => _treasure.activeSelf));
            Leaf moveToTreasure = new Leaf("MoveToTreasure", new ActionStrategy(() => _agent.SetDestination(_treasure.transform.position)));

            Sequence goToTreasure = new Sequence("GoToTreasure");
            goToTreasure.AddChild(new Leaf("IsTreasurePresent", new ConditionStrategy(() => _treasure.activeSelf)));
            goToTreasure.AddChild(new Leaf("MoveToTreasure", new ActionStrategy(() => _agent.SetDestination(_treasure.transform.position))));

            Sequence goToBox = new Sequence("GoToBox");
            goToBox.AddChild(new Leaf("IsBoxPresent", new ConditionStrategy(() => _box.activeSelf)));
            goToBox.AddChild(new Leaf("MoveToBox", new ActionStrategy(() => _agent.SetDestination(_box.transform.position))));

            Selector goToCollectibles = new Selector("GoToCollectibles");
            goToCollectibles.AddChild(goToTreasure);
            goToCollectibles.AddChild(goToBox);

            _behaviorTree.AddChild(goToCollectibles);
        }

        private void Update()
        {
            _behaviorTree.Process();
        }

    }

}
