using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Orb : MonoBehaviour
{
    [SerializeField] private ParticleSystem normalPs;
    [SerializeField] private ParticleSystem collectionPs;
    [SerializeField] protected float killDelay = 1f;
    private Collider2D col;
    private SpriteRenderer sr;
    private HoverBounce hoverBounce;
    public Sprite[] orbSprites;

    public UnityEvent OnBehaviorComplete;
    
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
    public void DelayKill() {
        StartCoroutine(DelayedKill());
    }
    private IEnumerator DelayedKill() {
        col.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sr.gameObject.SetActive(false);
        if (normalPs) normalPs.Stop();
        if (collectionPs) collectionPs.Play();
        yield return new WaitForSeconds(killDelay);
        if (hoverBounce) hoverBounce.KillHover();
        OnBehaviorComplete.Invoke();
    }
}
