using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VladekPetting : MonoBehaviour
{
    public static VladekPetting Instance;

    [HideInInspector] public bool isPetted;
    
    private Transform clickedObject;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }
    private void Start()
    {
        isPetted = false;
    }

    void Update()
    {
        // check for touch input
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                handleClick();
            }
        }
    }

    void handleClick()
    {
        // draw a Ray perpendicular to the camera at the clicked position
        // and create a RayHit to capture the first object that our Ray intersects
        Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.transform.tag == "Clickable")
            {
                // do something with the object that was clicked
                StartCoroutine(Petted());
                // reset ray and rayHit for the next click
                ray = new Ray();
                rayHit = new RaycastHit();
            }
            else if (clickedObject != null)
            {
                // draw a plane on the xz axis at the clickedObject's y position
                Plane xzPlane = new Plane(Vector3.up, clickedObject.position);
                float distance;
                // find the point where our click intersects the plane
                // and move the clickedObject to it's new position
                if (xzPlane.Raycast(ray, out distance))
                {
                    clickedObject.position = ray.GetPoint(distance);
                }
            }
        }
    }

    IEnumerator Petted()
    {
        AudioManager.Instance.PlaySound("petting");
        isPetted = true;
        VladekNeeds.Instance.funNeed += VladekNeeds.Instance.funRise / 3;
        VladekNeeds.Instance.funNeed = Mathf.Round(VladekNeeds.Instance.funNeed * 1000.0f) * 0.001f;
        yield return new WaitForSeconds(1);
        isPetted = false;
        AudioManager.Instance.audioSrc.Stop();
    }
}
