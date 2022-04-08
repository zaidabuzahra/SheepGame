using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    private SheepSpawner SPRefrence;

    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;

    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;

    public float HeartOffset;
    public GameObject HeartPrefab;
    // Start is called before the first frame update
    private void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        GameStateManager.Instance.SavedSheep();

        SPRefrence.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;

        SoundManager.Instance.PlaySheepHitClip();
        Instantiate(HeartPrefab, transform.position + new Vector3(0, HeartOffset, 0), Quaternion.identity);

        TweenScaling tweenScaling = gameObject.AddComponent<TweenScaling>();
        tweenScaling.TargetScale = 0;
        tweenScaling.TimeToReachScale = gotHayDestroyDelay;
        Destroy(gameObject, gotHayDestroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
        }
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }
    }

    private void Drop()
    {
        
        SoundManager.Instance.PlaySheepDropClip();

        SPRefrence.RemoveSheepFromList(gameObject);

        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;

        

        Destroy(gameObject, dropDestroyDelay);
        
        GameStateManager.Instance.DroppedSheep();
    }

    public void SetSpawner(SheepSpawner Spawner)
    {
        SPRefrence = Spawner;
    }
}