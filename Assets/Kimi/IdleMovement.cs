using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMovement : MonoBehaviour
{

    [SerializeField] GameObject anchorPointsContainer;
    [SerializeField] GameObject interactPosition;
    private List<GameObject> anchorPoints = new();
    public bool isActive = false;
    public bool movementStarted = true;
    public Transform counterTarget;
    public Animator animator;
    public float timeCount = 0f;
    public CallNPC call;

    void Start()
    {
        foreach (Transform child in anchorPointsContainer.transform)
        {
            anchorPoints.Add(child.gameObject);
            Debug.Log(child.gameObject.name);
        }
        StartCoroutine(StartMovement());
    }

    public IEnumerator StartMovement()
    {
        int randIndex = -1;
        int lastIndex = randIndex;
        movementStarted = true;
        while (movementStarted)
        {
            if (!isActive)
            {
                randIndex = Random.Range(0, anchorPoints.Count);
                if (randIndex != lastIndex)
                {
                    StartCoroutine(MoveTo(anchorPoints[randIndex]));
                }
            lastIndex = randIndex;
            }
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }

    public IEnumerator StopMovement()
    {
        movementStarted = false;
        while (true)
        {
            if (!isActive)
            {
                StartCoroutine(MoveTo(interactPosition));
                break;
            }
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }

    private IEnumerator MoveTo(GameObject target)
    {
        isActive = true;
        // If the target is null or not active, we don't want to move towards it.
        Debug.Log("Movement Started");
        if (target == null || !target.activeInHierarchy)
        {
            // Log an error if the target is null or inactive.
            yield break; // Exit the coroutine.
        }

        // Log that we are starting the movement towards the target.

        // Start the "Walking" animation.
        Animator animator = gameObject.GetComponent<Animator>();
        animator.CrossFade(Animator.StringToHash("Walking"), 0.01f);

        // Define move speed. This could also be a parameter or calculated dynamically if needed.
        float moveSpeed = 0.6f;

        // The stopping distance to the target, to avoid overshooting or getting too close.
        float stoppingDistance = 0.4f;

        // Loop until the character is within the stopping distance to the target.
        while (Vector3.Distance(transform.position, target.transform.position) > stoppingDistance)
        {
            // Make sure the target is still active during the movement.
            if (!target.activeInHierarchy)
            {
                // Log and break if the target has been deactivated during the movement.
                yield break;
            }

            // Calculate the direction towards the target
            Vector3 direction = (target.transform.position - transform.position).normalized;

            // Ensure the character stays upright by zeroing the y-component of the direction.
            direction.y = 0;

            // Rotate the character to face the target using a slerp for smoother rotation.
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    Time.deltaTime * 5f);

                // Move the character towards the target position.
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position,
                    moveSpeed * Time.deltaTime);
            
            // Yield until the next frame.
            yield return null;
        }

        // Transition to the "Idle" animation once we've reached the target.
        
        //transform.LookAt(counterTarget.position);
        animator.CrossFade(Animator.StringToHash("Idle"), 0.1f);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(counterTarget.position), Time.deltaTime * 5f);
        isActive = false;
    }

    public IEnumerator TurnToPlayer()
    {
        while (call.onTrigger == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(counterTarget.position), timeCount);
            timeCount = timeCount + Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    //private ienumerator movetocounter(gameobject target)
    //{
    //    isactive = true;
    //    // if the target is null or not active, we don't want to move towards it.
    //    debug.log("movement started");
    //    if (target == null || !target.activeinhierarchy)
    //    {
    //        // log an error if the target is null or inactive.
    //        yield break; // exit the coroutine.
    //    }

    //    // log that we are starting the movement towards the target.

    //    // start the "walking" animation.
    //    animator animator = gameobject.getcomponent<animator>();
    //    animator.crossfade(animator.stringtohash("walking"), 0.01f);

    //    // define move speed. this could also be a parameter or calculated dynamically if needed.
    //    float movespeed = 0.6f;

    //    // the stopping distance to the target, to avoid overshooting or getting too close.
    //    float stoppingdistance = 0.4f;

    //    // loop until the character is within the stopping distance to the target.
    //    while (vector3.distance(transform.position, target.transform.position) > stoppingdistance)
    //    {
    //        // make sure the target is still active during the movement.
    //        if (!target.activeinhierarchy)
    //        {
    //            // log and break if the target has been deactivated during the movement.
    //            yield break;
    //        }

    //        // calculate the direction towards the target
    //        vector3 direction = (countertarget.transform.position - transform.position).normalized;

    //        // ensure the character stays upright by zeroing the y-component of the direction.
    //        direction.y = 0;

    //        // rotate the character to face the target using a slerp for smoother rotation.
    //        transform.rotation = quaternion.slerp(transform.rotation, quaternion.lookrotation(direction),
    //            time.deltatime * 5f);

    //        // move the character towards the target position.
    //        transform.position = vector3.movetowards(transform.position, target.transform.position,
    //            movespeed * time.deltatime);

    //        // yield until the next frame.
    //        yield return null;
    //    }

    //     transition to the "idle" animation once we've reached the target.
    //    animator.crossfade(animator.stringtohash("idle"), 0.1f);
    //    isactive = false;
    //}


    }