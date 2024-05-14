using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FrameSwapperAnimation
{
    [SerializeField] string animationId = null;
    [SerializeField] Sprite[] frames = null;
    [SerializeField] float frameTime = 1.0f;
    [SerializeField] bool loop = false;

    public int FrameCount => frames.Length;

    public float FrameTime => frameTime;

    public bool IsLoopable => loop;

    public string AnimationId => animationId;

    public void ApplyFrame(SpriteRenderer i_rnd, int i_index)
    {
        if (null == i_rnd) return;
        if (FrameCount == 0) return;

        i_index = Mathf.Clamp(i_index, 0, FrameCount - 1);
        i_rnd.sprite = frames[i_index];
    }
}


public class FrameSwapper : MonoBehaviour
{
    [SerializeField] FrameSwapperAnimation[] anims = null;
    [SerializeField] SpriteRenderer spRenderer = null;

    Coroutine playRoutine = null;
    FrameSwapperAnimation currentAnimation = null;
    Dictionary<string, FrameSwapperAnimation> animationsById = null;

    private void Awake()
    {
        animationsById = new Dictionary<string, FrameSwapperAnimation>();

        int count = anims.Length;
        for (int i = 0; i < count; i++)
        {
            string id = anims[i].AnimationId;
            if (!string.IsNullOrEmpty(id) && !animationsById.ContainsKey(id))
                animationsById.Add(id, anims[i]);
        }

    }


    public void Play(string i_animationId)
    {
        if (string.IsNullOrEmpty(i_animationId)) return;

        FrameSwapperAnimation anim = null;
        if(true == animationsById.TryGetValue(i_animationId, out anim))
        {
            Stop();
            currentAnimation = anim;
            playRoutine = StartCoroutine(swapFrames(anim));
        }
    }

    public void Stop()
    {
        if(null != playRoutine)
        {
            StopCoroutine(playRoutine);
            playRoutine = null;
        }

        currentAnimation = null;
    }

    public bool IsPlaying => playRoutine != null;

    public FrameSwapperAnimation CurrentAnimation => currentAnimation;

    IEnumerator swapFrames(FrameSwapperAnimation i_anim)
    {
        // TODO : wrap this nested coroutine into looping logic

        yield return StartCoroutine(loopThroughFrames(i_anim));
    }

    IEnumerator loopThroughFrames(FrameSwapperAnimation i_anim)
    {
        int count = i_anim.FrameCount;
        for (int i = 0; i < count; i++)
        {
            i_anim.ApplyFrame(spRenderer, i);
            yield return new WaitForSeconds(i_anim.FrameTime);
        }
    }

}
