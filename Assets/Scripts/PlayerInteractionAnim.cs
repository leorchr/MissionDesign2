using UnityEngine;

public enum InteractionType
{
    None,
    Analyser,
    PushButton,
    OpenChest,
    FailedAction,
    Pickup,
    Talk
}

public class PlayerInteractionAnim : MonoBehaviour
{
    private Animator _animator;

    public static bool AnimationInProgress = false;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void BeginAnimation()
    {
        AnimationInProgress = true;
    }

    public void EndAnimation()
    {
        AnimationInProgress = false;
    }

    public bool PlayAnimation(InteractionType animation)
    {
        //if an animation is already in progress or we are trying to do something while walking
        if (AnimationInProgress || _animator.GetFloat("Speed") > 1) return false;
        switch (animation)
        {
            case InteractionType.Analyser:
                {
                    _animator.SetTrigger("Analyser");
                    break;
                }
            case InteractionType.PushButton:
                {
                    _animator.SetTrigger("Push Button");
                    break;
                }
            case InteractionType.OpenChest:
                {
                    _animator.SetTrigger("Open Chest");
                    break;
                }
            case InteractionType.FailedAction:
                {
                    _animator.SetTrigger("Failed");
                    break;
                }
            case InteractionType.Pickup:
                {
                    _animator.SetTrigger("Pickup");
                    break;
                }
        }

        return false;
    }
}