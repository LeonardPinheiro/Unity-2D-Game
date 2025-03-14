using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 5f;
    public Transform[] destination;

    int currentIndex = 0;

    Animator animator;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destination.Length == 0)
        {
            animator.SetBool("b_isWalk", false);
            return;
        }
            animator.SetBool("b_isWalk", true);

        var currentDestination = destination[currentIndex];

        sprite.flipX = transform.position.x > currentDestination.position.x;

        transform.position = Vector3.MoveTowards(transform.position, currentDestination.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentDestination.position) <= 0.1f) 
        {
            currentIndex = (currentIndex + 1) % destination.Length;
        }

    }
}
