using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMovement : MonoBehaviour
{

    [SerializeField] GameObject anchorPointsContainer;
    [SerializeField] GameObject interactPosition;
    private List<GameObject> anchorPoints = new();
    bool isActive = false;
    bool movementStarted = true;

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
        float stoppingDistance = 0.6f;

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
        animator.CrossFade(Animator.StringToHash("Idle"), 0.1f);
        isActive = false;
    }


}