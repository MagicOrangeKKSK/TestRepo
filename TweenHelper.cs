using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TweenHelper 
{
<<<<<<< HEAD
    public static IEnumerator MoveTo(Transform transform, Vector3 start, Vector3 end, float time, Action backCall = null)
    {
        yield return TimeTo(time, t => { transform.position = Vector3.Lerp(start, end, t); }, backCall);
=======
     public static IEnumerator MoveTo( Transform transform, Vector3 start, Vector3 end, float time, Action backCall = null)
    {
        yield return TimeTo(time, t => { transform.position = Vector3.Lerp(start, end, t); });
        backCall?.Invoke();
>>>>>>> 8bd0c5a3619f33ae9e193836c1d7a29dc918fe5a
    }

    public static IEnumerator SizeTo(Transform transform, Vector3 start, Vector3 end, float time, Action backCall = null)
    {
<<<<<<< HEAD
        yield return TimeTo(time, t => { transform.localScale = Vector3.Lerp(start, end, t); }, backCall);
    }

    public static IEnumerator ColorTo(SpriteRenderer sprite, Color start, Color end, float time, Action backCall = null)
    {
        yield return TimeTo(time, t => { sprite.color = Color.Lerp(start, end, t); }, backCall);
    }

    public static IEnumerator TimeTo(float time, Action<float> action, Action backCall = null)
=======
        yield return TimeTo(time, t => { transform.localScale = Vector3.Lerp(start, end, t); });
        backCall?.Invoke();
    }

    public static IEnumerator ColorTo(SpriteRenderer sprite,Color start,Color end,float time, Action backCall = null)
    {
        yield return TimeTo(time, t => { sprite.color = Color.Lerp(start, end, t);});
        backCall?.Invoke();
    }

    public static IEnumerator TimeTo(float time, Action<float> action, Action backCall=null)
>>>>>>> 8bd0c5a3619f33ae9e193836c1d7a29dc918fe5a
    {
        var timer = 0f;
        while (timer <= time)
        {
            timer += Time.fixedDeltaTime;
            action?.Invoke(timer / time);
            yield return new WaitForFixedUpdate();
        }
        backCall?.Invoke();
    }
}
