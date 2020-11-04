﻿using System;
using System.Collections;
using System.Collections.Generic;
using GameToBeNamed.Character;
using GameToBeNamed.Utils;
using UnityEngine;

namespace GameToBeNamed.Character.Bullets {

    public class StandardBullet : MonoBehaviour {

        [SerializeField] private Collision2DProxy m_colliderBox;
        [SerializeField] private int m_damage;
        [SerializeField] private float m_speed;
        [SerializeField] private GameObject m_onContactExplosion;
        [SerializeField] private LayerMask m_targetLayer;
        [SerializeField] private LayerMask m_wallLayer;


        private void Awake() {
            m_colliderBox.OnTrigger2DEnterCallback.AddListener(OnTrigger2DEnterCallback);
            Destroy(gameObject, .2f);
        }

        private void FixedUpdate() {
            var direction = m_speed * Time.deltaTime * transform.localScale.x;
            
            transform.position += new Vector3(direction, 0, 0);
        }

        private void OnTrigger2DEnterCallback(Collider2D ev) {
            
            if (((1 << ev.gameObject.layer) & m_targetLayer) == 0  || gameObject == null) {
                return;
            }
            
            if (((1 << ev.gameObject.layer) & m_wallLayer) == 0) {
                var contactExplosion = Instantiate(m_onContactExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                return;
            }
            
            var info = new OnAttackTriggerEnter.Info {
                Emiter = gameObject, Receiver = ev.gameObject
            };
            GameManager.Instance.GlobalDispatcher.Emit(new OnAttackTriggerEnter(info, m_damage, ev.bounds.center));
            var temContactExplosion = Instantiate(m_onContactExplosion, ev.bounds.center, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(gameObject, 2f);
        }
    }
}
