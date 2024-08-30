using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Runtime
{
    public class PatrolPoints : MonoBehaviour
    {
        #region Publics

        public List<GameObject> m_patrolPointsList = new List<GameObject>();

        #endregion

        #region Unity API

        // Start is called before the first frame update


    	// Update is called once per frame
    	void Update()
    	{
			
    	}

        #endregion

        #region Main methods

        private void OnDrawGizmos()
        {
            if (m_patrolPointsList == null) return;

            for (int i = 0; i < m_patrolPointsList.Count; i++)
            {
                if (i < m_patrolPointsList.Count - 1)
                {
                    Gizmos.DrawLine(m_patrolPointsList[i].transform.position, m_patrolPointsList[i + 1].transform.position);
                }
            }

            Gizmos.DrawLine(m_patrolPointsList[0].transform.position, m_patrolPointsList[m_patrolPointsList.Count - 1].transform.position);
        }

        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

	
        #endregion
    }

}
