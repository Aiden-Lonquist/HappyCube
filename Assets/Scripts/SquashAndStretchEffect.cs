using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashAndStretchEffect : MonoBehaviour
{
    [Header("Squash and stretch Core")]
    [SerializeField, Tooltip("This is the tooltip.")] private Transform transformToAffect;
    [SerializeField] private SquashStretchAxis axisToAffect = SquashStretchAxis.y;
    [SerializeField] private float animationDuration = 0.2f;
    [SerializeField] private bool canBeOverwritten;
    [SerializeField] private bool playOnStart;

    [Flags]
    public enum SquashStretchAxis
    {
        None = 0,
        x = 1,
        y = 2,
        z = 4
    };

    [SerializeField] private float initialScale = 1f;
    [SerializeField] private float maximumScale = 1.3f;
    [SerializeField] private bool resetScaleAfterAnimation = true;

    [SerializeField]
    private AnimationCurve squashAndStretchCurve = new(
            new Keyframe(0f, 0f),
            new Keyframe(0.25f, 1f),
            new Keyframe(1f, 0f)
        );

    [SerializeField] private bool looping;
    [SerializeField] private float loopingDelay = 0.5f;

    private Coroutine squashAndStretchCoroutine;
    private WaitForSeconds loopingDelayTime;
    private Vector3 initialScaleVector;


    private bool affectX => (axisToAffect & SquashStretchAxis.x) != 0;
    private bool affectY => (axisToAffect & SquashStretchAxis.y) != 0;
    private bool affectZ => (axisToAffect & SquashStretchAxis.z) != 0;
    
    private void Awake()
    {
        if (transformToAffect == null)
        {
            transformToAffect = transform;
        }

        initialScaleVector = transformToAffect.localScale;
        loopingDelayTime = new WaitForSeconds(loopingDelay);
    }

    private void Start()
    {
        if (playOnStart)
        {
            CheckForAndStartCoroutine();
        }
    }

    public void PlaySquashAndStretch()
    {
        if (looping && !canBeOverwritten)
        {
            return;
        }

        CheckForAndStartCoroutine();
    }

    private void CheckForAndStartCoroutine()
    {
        if (axisToAffect == SquashStretchAxis.None) {
            Debug.Log("Axis set to none");
        }

        if (squashAndStretchCoroutine != null)
        {
            StopCoroutine(squashAndStretchCoroutine);
        }

        squashAndStretchCoroutine = StartCoroutine(SquashAndStretchFunction());
    }

    private IEnumerator SquashAndStretchFunction()
    {
        do
        {
            float elapsedTime = 0;
            Vector3 originalScale = initialScaleVector;
            Vector3 modifiedScale = originalScale;

            while (elapsedTime < animationDuration)
            {
                elapsedTime += Time.deltaTime;

                float curvePosition = elapsedTime / animationDuration;

                float curveValue = squashAndStretchCurve.Evaluate(curvePosition);
                float remappedValue = initialScale + (curveValue * (maximumScale - initialScale));

                float minimumThreshhold = 0.0001f;
                if (Mathf.Abs(remappedValue) < minimumThreshhold)
                {
                    remappedValue = minimumThreshhold;
                }

                if (affectX)
                {
                    modifiedScale.x = originalScale.x * remappedValue;
                }
                else
                {
                    modifiedScale.x = originalScale.x / remappedValue;
                }

                if (affectY)
                {
                    modifiedScale.y = originalScale.y * remappedValue;
                }
                else
                {
                    modifiedScale.y = originalScale.y / remappedValue;
                }

                if (affectZ)
                {
                    modifiedScale.z = originalScale.z * remappedValue;
                }
                else
                {
                    modifiedScale.z = originalScale.z / remappedValue;
                }

                transformToAffect.localScale = modifiedScale;

                yield return null;
            }

            if (resetScaleAfterAnimation)
            {
                transformToAffect.localScale = originalScale;
            }

            if (looping)
            {
                yield return loopingDelayTime;
            }
        } while (looping);
    }

    public void SetLooping(bool shouldLoop)
    {
        looping = shouldLoop;
    }

    public void LandingAnimation()
    {
        CheckForAndStartCoroutine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
