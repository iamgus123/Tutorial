using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public UnityEvent OnGrab;
    public UnityEvent OnRelease;

    private bool isDestroyed = false;
    private Magazine magazine;
    
    public void Awake()
    {
        magazine = GetComponent<Magazine>();
    }

    public void Grab(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;
        if (interactor is XRDirectInteractor)
        {
            var hand = interactor.transform.GetComponent<Hand>();
            magazine.NowMagazine(hand.getHand());
            OnGrab?.Invoke();
        }
    }

    public void Release(SelectExitEventArgs args)
    {
        var interactor = args.interactorObject;
        if (interactor is XRDirectInteractor)
        {
            magazine.Realeasemagazine();
            OnRelease?.Invoke();
        }
    }

    public void Destroy()
    {
        magazine.Realeasemagazine();
        if (isDestroyed)
            return;
        isDestroyed = true;

        Destroy(gameObject, 1f);
    }
}