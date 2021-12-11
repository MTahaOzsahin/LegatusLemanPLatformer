using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : Health, IDamageable<int>
{
    public SpriteRenderer spriteRenderer;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        HitFeedBack();

        if (CheckIfWeDead())
        {
            OnDeath();
        }
    }

    protected override void HitFeedBack()
    {
        base.HitFeedBack();

        this.gameObject.transform.DOShakePosition(0.15f, new Vector3(0.4f, 0.1f, 0), 10, 90);
        Tween colorTween = this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.red, 0.1f);
        colorTween.OnComplete(() =>
        this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.white, 0.05f));
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        this.gameObject.transform.DOShakePosition(0.15f, new Vector3(0.4f, 0.1f, 0), 10, 90);
        Tween colorTween = this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.red, 0.1f);
        colorTween.OnComplete(() => Destroy(gameObject));
    }
}

