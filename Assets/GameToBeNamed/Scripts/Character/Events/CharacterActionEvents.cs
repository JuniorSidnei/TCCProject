﻿using GameToBeNamed.Utils;
using UnityEngine;

namespace GameToBeNamed.Character {

    public class OnCharacterUpdate { }

    public class OnCharacterFixedUpdate { }

    public class OnWallSliding {
        public OnWallSliding(bool onWall) {
            OnWall = onWall;
        }

        public bool OnWall;
    }

    public class OnFirstAttack { }

    public class OnSecondAttack {
        public OnSecondAttack(int comboStep) {
            ComboStep = comboStep;
        }

        public int ComboStep;
    }

    public class OnThirdAttack { }

    public class OnDashing { }

    public class OnBlocking { }

    public class OnJumpAttack { }
    
    public class OnFinishDeath { }

    public class OnReceivedAttack {
        public OnReceivedAttack(int damage, Vector2 damageContact, OnAttackTriggerEnter.Info attackInfo,
            bool onBlocking = false) {
            Damage = damage;
            OnBlocking = onBlocking;
            DamageContact = damageContact;
            AttackInfo = attackInfo;
        }

        public int Damage;
        public bool OnBlocking;
        public Vector2 DamageContact;
        public OnAttackTriggerEnter.Info AttackInfo;
    }

    //Animator events
    public class OnBlockFinish { }

    public class OnExecuteAttack { }

    public class OnWarriorAirAttack { }

    public class OnRogueAirAttack { }

    public class OnFirstAttackFinish { }

    public class OnSecondAttackFinish { }
    
    public class OnTerminateAttack { }

    public class OnDeath {
        public OnDeath(Character2D character) {
            Character = character;
        }
        public Character2D Character;
    }
    
  
}