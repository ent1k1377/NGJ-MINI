using System.Collections;
using UnityEngine;

public class JumpFX : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;

    [ContextMenu("Play Animations")]
    public void PlayAnimation(Transform jumper, float duration)
    {
        StartCoroutine(AnimationByTime(jumper, duration));
    }

    private IEnumerator AnimationByTime(Transform jumper, float duration)
    {
        float expiredSeconds = 0f;
        float progress = 0f;

        Vector2 startPosition = jumper.position;

        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            jumper.position = new Vector2(jumper.position.x, startPosition.y + _yAnimation.Evaluate(progress));
            //jumper.position = startPosition + new Vector2(0, _yAnimation.Evaluate(progress));


            yield return null;
        }
    }
}
