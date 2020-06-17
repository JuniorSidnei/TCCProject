﻿using UnityEngine;
using Rewired;


namespace GameToBeNamed.Character {
    
    [System.Serializable]
    public class PlayerInput : InputSource {

        public int PlayerID = 0;
        private Player m_player;

        public override void Configure(Character2D character) {
            m_player = ReInput.players.GetPlayer(PlayerID);
        }

        public override void Update() {
            
            CheckButtonDown("Jump", InputAction.Button1);
            CheckButton("Jump", InputAction.Button1);
            CheckButton("MoveRight", InputAction.Button2);
            CheckButton("MoveLeft", InputAction.Button3);
            CheckButtonDown("Attack", InputAction.Button4);
            CheckButtonDown("Blocking", InputAction.Button5);
            CheckButtonDown("Dash", InputAction.Button6);
            CheckButtonDown("ChangeClass", InputAction.Button7);
        }

        
        private void CheckButton(string buttonName, InputAction actionValue) {
            
            if (m_player.GetButton(buttonName)) {
                SetAction(actionValue);
            }
            else {
                UnsetAction(actionValue);
            }
        }
        
        private void CheckButtonDown(string buttonName, InputAction actionValue) {
            
            if (m_player.GetButtonDown(buttonName)) {
                SetActionDown(actionValue);
            }
            else {
                UnsetActionDown(actionValue);
            }
        }
        
        private void CheckButtonUp(string buttonName, InputAction actionValue) {
            if (m_player.GetButtonUp(buttonName)) {
                SetActionUp(actionValue);
            }
            else {
                UnsetActionUp(actionValue);
            }
        }
    }
}