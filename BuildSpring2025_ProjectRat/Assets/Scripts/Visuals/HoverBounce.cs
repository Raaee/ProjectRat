using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBounce : MonoBehaviour
{
    [SerializeField] private GameObject objToMove;
    [SerializeField] private float duration = 2f;
    [SerializeField] private float maxHoverHeight = 1f;
    [SerializeField] private Ease easeType = Ease.Linear;
    private Tween tween;
    private void Start() {
        StartHover();
    }
    public void StartHover() {
        StartCoroutine(Hover());     
    }
    private IEnumerator Hover() {
        Vector3 startPos = transform.position;
        do {
            float hoverHeight = Random.Range(maxHoverHeight/2, maxHoverHeight);
            Vector3 endPoint = new Vector3(startPos.x, startPos.y + hoverHeight, 0);
            tween = objToMove.transform.DOMove(endPoint, duration).SetEase(easeType);
            yield return new WaitUntil(IsTweenComplete);
            tween = objToMove.transform.DOMove(startPos, duration).SetEase(easeType);
            yield return new WaitUntil(IsTweenComplete);
        }
        while (IsTweenComplete());
    }
    private bool IsTweenComplete() {
        return tween.IsActive() == false;
    }
    public void KillHover() {
        tween.Complete();
    }
}
