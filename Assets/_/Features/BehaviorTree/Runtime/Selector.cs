using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Runtime
{
    public class Selector : Composite
    {
        // Selector will return a success if any of its children succeed and not process any further children.
        public override State Process()
        {
            var childState = m_children[m_index].Process();

            Debug.Log(childState);

            // IF ANY OF NODE IS SUCCESS, RETURN SUCCESS AND EXIT NODE
            if (childState == State.SUCCESS)
            {
                m_index = 0;
                return State.SUCCESS;
            }

            // IF FAIL, GO CHECK FOR NEXT NODE
            if (childState == State.FAIL)
            {
                m_index++;

                // IF ALL NODES ARE FAIL, RETURN FAIL AND EXIT NODE
                if (m_index >= m_children.Count)
                {
                    m_index = 0;
                    return State.FAIL;
                }

                // STILL NODES TO CHECK
                return State.RUNNING;
            }

            // NOT SUCCESS OR FAIL => CONTINUE RUNNING UNTIL FAIL OR SUCCESS
            return State.RUNNING;
        }
    }

}
