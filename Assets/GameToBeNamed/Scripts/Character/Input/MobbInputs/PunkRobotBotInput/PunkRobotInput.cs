﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameToBeNamed.Character {

    [System.Serializable]
    public class PunkRobotInput : BotInput {
       
        [SerializeField] private StateMachine m_stateMachine;

        private Character2D m_char;

        [SerializeField] private List<Vector3> m_wayPoints;
        private Vector3 currentWayPoint;
        private int currentWayPointIndex;
        
        public override void Configure(Character2D character) {
            m_char = character;
            m_stateMachine.OnConfigure();
            m_stateMachine.ChangeState<PatrolState>(m_char, this);
        }

        public override void Update() {
            m_stateMachine.OnUpdate(m_char, this);
        }

        public override void SetDestination(out Transform target) {
            throw new System.NotImplementedException();
        }

        public override bool SearchDestination() {
            throw new System.NotImplementedException();
        }

        public override void MoveToDestination() {
            
            if (m_char.transform.position.x < currentWayPoint.x) {
                UnsetAction(InputAction.Button3);
                SetAction(InputAction.Button2);
            }
            else if(m_char.transform.position.x > currentWayPoint.x) {
                UnsetAction(InputAction.Button2);
                SetAction(InputAction.Button3);
            }
        }

        public override void SetInitialDestination() {
            currentWayPointIndex = 0;
            currentWayPoint = m_wayPoints[currentWayPointIndex];
        }

        public override bool IsDestinationReached() {
            if (Vector3.Distance(m_char.transform.position, currentWayPoint) < 1f) {
                return true;
            }
            return false;
        }

        public override void SetNextDestination() {
            currentWayPoint = m_wayPoints[++currentWayPointIndex % m_wayPoints.Count];
        }
    }
}