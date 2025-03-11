using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : Collectable
{
    [SerializeField] private ParticleSystem normalPs;
    [SerializeField] private ParticleSystem collectionPs;
    private Collider2D col;
    private SpriteRenderer sr;
    private HoverBounce hoverBounce;
    public Sprite[] orbSprites;

    private void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        hoverBounce = GetComponent<HoverBounce>();
        col = GetComponent<CircleCollider2D>();
        ChooseRandomVisual();
    }
    private void ChooseRandomVisual() {
        int rand = Random.Range(0, orbSprites.Length-1);
        sr.sprite = orbSprites[rand];
    }
    public override void Collect(GameObject collector) {
        FindObjectOfType<AcidOrbs>().AddOrbs(1);
    }
    protected override IEnumerator DelayedKill() {
        col.enabled = false;
        sr.sprite = null;
        normalPs.Stop();
        collectionPs.Play();
        yield return new WaitForSeconds(1f);
        hoverBounce.KillHover();
        DestroySelf();
    }

    public override void MinionCollect(GameObject collector) {}
   
}
