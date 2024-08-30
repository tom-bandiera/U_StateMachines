using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Runtime
{
    public class MyFirstBehaviorTree : MonoBehaviour 
    {
        /*private Selector _mainNode;
        private Sequence _composite01;
        private Selector _selector;*/
        [SerializeField] private GameObject _gameObject;

        private AllNodesCheckSelector _mainNode;


        private void Awake()
        {
            /* 
            _mainNode = new Selector();
            _composite01 = new Sequence();

            _composite01.m_children.Add(new ReturnFailLeaf());
            _composite01.m_children.Add(new TellMeSomethingLeaf("Bonjour!"));
            _composite01.m_children.Add(new WaitForSecondsLeaf(2));
            _composite01.m_children.Add(new ActivateGameObjectLeaf(_gameObject, true));
            _composite01.m_children.Add(new WaitForSecondsLeaf(2));
            _composite01.m_children.Add(new ActivateGameObjectLeaf(_gameObject, false));
            _composite01.m_children.Add(new WaitForSecondsLeaf(2));
            _composite01.m_children.Add(new TellMeSomethingLeaf("Ceci est une séquence!"));

            _selector = new Selector();
            _selector.m_children.Add(new TellMeSomethingLeaf("This is a Selector"));

            _mainNode.m_children.Add(_composite01);
            _mainNode.m_children.Add(_selector);
            */

            _mainNode = new AllNodesCheckSelector();

            _mainNode.m_children.Add(new ReturnFailLeaf());
            _mainNode.m_children.Add(new TellMeSomethingLeaf("Hi"));
            _mainNode.m_children.Add(new TellMeSomethingLeaf("Hi 2"));
        }


        private void Update()
        {
            _mainNode.Process();
        }
    }
}
