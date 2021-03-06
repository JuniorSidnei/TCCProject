﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameToBeNamed.Utils;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameToBeNamed.Character {
    
    public class JunkPieces : MonoBehaviour {

        public LayerMask PlayerLayer;
        public int JunkAmountRangeMin;
        public int JunkAmountRangeMax;
        private int m_pieceAmount;
        private Rigidbody2D m_rb;
        private void Start() {

            m_rb = GetComponent<Rigidbody2D>();
            
            m_pieceAmount = Random.Range(JunkAmountRangeMin, JunkAmountRangeMax);

            m_rb.velocity += new Vector2(Random.Range(-30, 30), Random.Range(0, 60));
        }
        
        private void OnTriggerEnter2D(Collider2D other) {
           
            if (((1 << other.gameObject.layer) & PlayerLayer) == 0) return;
            
            
            GameManager.Instance.GlobalDispatcher.Emit(new OnCollectableJunkPieces(m_pieceAmount));
            Destroy(gameObject);
        }
    }
}