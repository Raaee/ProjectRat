using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : Collectable
{
    private SpriteRenderer sr;
    public Sprite[] orbSprites;
    private void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        ChooseRandomVisual();
    }
    private void ChooseRandomVisual() {
        int rand = Random.Range(0, orbSprites.Length-1);
        sr.sprite = orbSprites[rand];
    }
    public override void Collect() {
        FindObjectOfType<AcidOrbs>().AddOrbs(1);
    }
}
