using UnityEngine;

namespace StateMachine.Runtime
{
    public interface ICanUseStateMachine
    {
        public void DoIdle(float deltaTime)
        {

        }

        public void DoChasing(float deltaTime) 
        {
        
        }

        public void DoAttack(float deltaTime)
        {

        }

        public bool HasFoundTarget();

        public bool IsTargetInAttackRange();

    }
}