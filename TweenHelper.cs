using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TweenHelper 
{

    public static IEnumerator RotationTo(Transform transform ,Quaternion start, Quaternion end ,float time)
    {
        yield return TimeTo(time, t=> { transform.rotation = Quaternion.Lerp(start, end, t); });
    }

    public static IEnumerator MoveTo(Transform transform, Vector3 end, float time, Action backCall = null)
    {
        yield return MoveTo(transform, transform.position, end, time, backCall);
    }

    public static IEnumerator MoveTo(Transform transform, Vector3 start, Vector3 end, float time, Action backCall = null)
    {
        yield return TimeTo(time, t => { transform.position = Vector3.Lerp(start, end, t); }, backCall);
    }

    public static IEnumerator SizeTo(Transform transform,Vector3 end ,float time , Action backCall = null)
    {
        yield return SizeTo(transform, transform.localScale, end, time, backCall);
    }

    public static IEnumerator SizeTo(Transform transform, Vector3 start, Vector3 end, float time, Action backCall = null)
    {
        yield return TimeTo(time, t => { transform.localScale = Vector3.Lerp(start, end, t); }, backCall);
    }


    //颜色变换

    public static IEnumerator ColorTo(SpriteRenderer sprite,Color end ,float time ,Action backCall = null)
    {
        yield return ColorTo(sprite, sprite.color, end, time, backCall);
    }

    public static IEnumerator ColorTo(SpriteRenderer sprite, Color start, Color end, float time, Action backCall = null)
    {
        yield return TimeTo(time, t => { sprite.color = Color.Lerp(start, end, t); }, backCall);
    }

    public static IEnumerator ColorTo(MaskableGraphic graphic, Color end , float time ,Action backCall = null)
    {
        yield return ColorTo(graphic, graphic.color, end, time, backCall);
    }

    /// <summary>
    /// 颜色变换
    /// <para>
    /// Text,Image,Button,RawImage 均继承于MaskableGraphic
    /// </para>
    /// </summary>
    /// <param name="graphic">Text,Image,Button,RawImage 均继承于MaskableGraphic </param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="time"></param>
    /// <param name="backCall"></param>
    /// <returns></returns>
    public static IEnumerator ColorTo(MaskableGraphic graphic, Color start, Color end, float time, Action backCall = null)
    {
        yield return TimeTo(time, t => { graphic.color = Color.Lerp(start, end, t); }, backCall);
    }
  
    public static IEnumerator TimeTo(float time, Action<float> action, Action backCall = null)
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
