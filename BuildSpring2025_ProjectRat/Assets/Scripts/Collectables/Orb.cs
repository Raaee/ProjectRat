using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class Orb : Collectable
{
    [SerializeField] private ParticleSystem normalPs;
    [SerializeField] private ParticleSystem collectionPs;
=======
using UnityEngine.Events;

public class Orb : MonoBehaviour
{
    [SerializeField] private ParticleSystem normalPs;
    [SerializeField] private ParticleSystem collectionPs;
    [SerializeField] protected float killDelay = 1f;
>>>>>>> main
    private Collider2D col;
    private SpriteRenderer sr;
    private HoverBounce hoverBounce;
    public Sprite[] orbSprites;

<<<<<<< HEAD
=======
    public UnityEvent OnBehaviorComplete;
    
>>>>>>> main
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
<<<<<<< HEAD
    public override void Collect() {
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
=======
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
>>>>>>> main
    }
}
