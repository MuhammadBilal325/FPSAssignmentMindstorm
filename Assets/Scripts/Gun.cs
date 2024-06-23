using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private Animator GunAnimator;
    [SerializeField] private Transform muzzleParticleSystem;
    [SerializeField] private Transform muzzlePoint;
    private string SHOOT_TRIGGER = "Shoot";
    void Start() {
        Player.Instance.ShootPerformed += Player_ShootPerformed; ;
    }

    private void Player_ShootPerformed(object sender, System.EventArgs e) {
        GunAnimator.SetTrigger(SHOOT_TRIGGER);
        Destroy(Instantiate(muzzleParticleSystem, muzzlePoint).gameObject, 0.1f);
    }
}
