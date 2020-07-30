﻿using System;
using System.Collections;
using System.Collections.Generic;
using GameToBeNamed.Character;
using GameToBeNamed.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace GameToBeNamed.Character
{
    public class AnimatorProxy : BaseAnimatorProxy
    {
        private void Awake() {
            
            m_char2D.LocalDispatcher.Subscribe<OnFirstAttack>(OnFirstAttack);
            m_char2D.LocalDispatcher.Subscribe<OnSecondAttack>(OnSecondAttack);
            m_char2D.LocalDispatcher.Subscribe<OnThirdAttack>(OnThirdAttack);
            m_char2D.LocalDispatcher.Subscribe<OnDashing>(OnDashing);
            m_char2D.LocalDispatcher.Subscribe<OnBlocking>(OnBlocking);
            m_char2D.LocalDispatcher.Subscribe<OnJumpAttack>(OnJumpAttack);
            m_char2D.LocalDispatcher.Subscribe<OnWallSliding>(OnWallSliding);
            m_char2D.LocalDispatcher.Subscribe<OnReceivedAttack>(OnReceivedAttack);
        }

        //Onwall
        private void OnWallSliding(OnWallSliding ev) {
            m_anim.SetBool("OnWall", ev.OnWall);
        }

        //Jump
        private void OnJumpAttack(OnJumpAttack ev) {
            m_anim.SetTrigger("JumpAttack");
        }

        //Block
        private void OnBlocking(OnBlocking ev) {
            m_anim.SetTrigger("Blocking");
        }

        //Dash
        private void OnDashing(OnDashing ev) {
            m_anim.SetTrigger("Dash");
        }

        //First attack
        private void OnFirstAttack(OnFirstAttack ev) {
            m_anim.SetTrigger("FirstAttack");
        }

        //secondattack
        private void OnSecondAttack(OnSecondAttack ev) {
            m_anim.SetTrigger("SecondAttack");
        }

        //thrid attack
        private void OnThirdAttack(OnThirdAttack ev) {
            m_anim.SetTrigger("ThirdAttack");
        }
        
        //OnHit
        private void OnReceivedAttack(OnReceivedAttack ev) {
            m_anim.SetTrigger("OnHit");
        }
        
        private void FixedUpdate() {
            
            //OnGround
            m_anim.SetBool("OnGround", m_char2D.Controller2D.collisions.below);
            
            //Iddle
            m_anim.SetFloat("VelX", Mathf.Abs(m_char2D.PositionDelta.x));
            
            //Jump
            m_anim.SetFloat("VelY", m_char2D.PositionDelta.y);
        }

        
        public void DeactiveBlockBox() {
            m_char2D.LocalDispatcher.Emit(new OnBlockFinish());
        }

        public void ExecuteAttack() {
            m_char2D.LocalDispatcher.Emit(new OnAttack());
        }
        
        public void ExecuteWarriorAirAttack() {
            m_char2D.LocalDispatcher.Emit(new OnWarriorAirAttack());
        }
        
        public void ExecuteRogueAirAttack() {
            m_char2D.LocalDispatcher.Emit(new OnRogueAirAttack());
        }
        
        public void OnStrikePush() {
            m_char2D.LocalDispatcher.Emit(new OnStrike());
        }
        
        public void FinishAttack() {
            m_char2D.LocalDispatcher.Emit(new OnAttackFinish());
        }

        public void OnFinishReceiveDamage() {
            m_char2D.LocalDispatcher.Emit(new OnReceiveDamageFinish());
        }
    }
}