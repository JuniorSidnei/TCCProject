﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameToBeNamed.Character {
    public class MobAnimatorProxy : BaseAnimatorProxy {
        
        private void Start() {
            m_char2D.LocalDispatcher.Subscribe<OnReceivedAttack>(OnReceivedAttack);
            m_char2D.LocalDispatcher.Subscribe<OnFirstAttack>(OnFirstAttack);
        }

        private void FixedUpdate() {
            
            //OnGround
            m_anim.SetBool("OnGround", m_char2D.Controller2D.collisions.below);
            
            //Iddle/Run
            m_anim.SetFloat("VelX", Mathf.Abs(m_char2D.PositionDelta.x));
            
        }

        private void OnFirstAttack(OnFirstAttack ev) {
            m_anim.SetTrigger("FirstAttack");
        }

        private void OnReceivedAttack(OnReceivedAttack ev) {
            m_anim.SetTrigger("OnHit");
        }
        
        
        public void ExecuteAttack() {
            m_char2D.LocalDispatcher.Emit(new OnAttack());
        }
        
        public void FinishAttack() {
            m_char2D.LocalDispatcher.Emit(new OnAttackFinish());
        }
    }
}