
using UnityEngine;


public class DummyHit : MonoBehaviour


{
    public void TriggerHit()

    {
        GetComponent<Animator>().SetTrigger("Hit");
    }
}