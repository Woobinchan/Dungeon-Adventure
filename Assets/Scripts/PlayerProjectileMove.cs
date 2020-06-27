﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileMove : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;



    public GameObject destroyEffect; // 발사체가 사라질 때 효과

    private void Awake() {
    }
    private void Start() {
        Invoke("DestroyProjectile", lifeTime);
    }
    void Update() {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, 0.5f);

        if (hitInfo.collider != null) {

            if (hitInfo.collider.gameObject.layer.Equals(10)) {
                //Debug.Log("맞았음");
                if (hitInfo.collider.gameObject.tag == "boss") {
                    hitInfo.collider.GetComponent<BossMove>().Damaged(2);
                }
                else { 
                    hitInfo.collider.GetComponent<EnemyDamage>().TakeDamage(damage);
                }
                DestroyProjectile();
            }
            else if (hitInfo.collider.gameObject.layer.Equals(8)) {
                //Debug.Log("바닥 맞았음");
                DestroyProjectile();
            }
        }
    }
    void DestroyProjectile() {
        if (destroyEffect != null)
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
