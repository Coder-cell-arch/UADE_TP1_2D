
using UnityEngine;


public class DummyHit : MonoBehaviour


{
    public void TriggerHit()

    {
        // get component and activate the trigger   Hit
        GetComponent<Animator>().SetTrigger("Hit");
    }
}