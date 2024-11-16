using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Convert mouse position to a point in world space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 targetPos = ray.GetPoint(distance);
            // Move towards the target position
            Vector3 moveDirection = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            transform.position = new Vector3(moveDirection.x, transform.position.y, moveDirection.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            GetComponent<SnakeController>().Grow();
            FindObjectOfType<FoodSpawner>().SpawnFood();
        }
    }


}

