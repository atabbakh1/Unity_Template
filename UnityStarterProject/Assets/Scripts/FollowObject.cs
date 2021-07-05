using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public float hoverHeight = 1.0F;
    public float distanceThreshold = 10f;
    public float followSpeed = 3.5f;
    public Transform targetObject;
    public Material highlightMaterial;

    private Rigidbody rigidBody;
    private Material originalMaterial;


    void Start()
    {
        //store the original material
        originalMaterial = this.gameObject.GetComponent<MeshRenderer>().material;

        //grab and modify settings for the rigid body
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.drag = 1F;
        rigidBody.angularDrag =1F;
    }

    void Update()
    {     
        //add to the Y value so the object always float above the target
        Vector3 targetPosition = new Vector3(targetObject.position.x, targetObject.position.y + hoverHeight, targetObject.position.z);

        //is this object is within the threshold distance of the target?
        if(Vector3.Distance(transform.position, targetPosition) < distanceThreshold)
        {
            //if so; hightlight the object and make it follow the target
            this.gameObject.GetComponent<MeshRenderer>().material = highlightMaterial;
            transform.LookAt(targetPosition);
            transform.Translate(Vector3.forward * followSpeed * Time.deltaTime);
        }
        else
        {
            //Otherwise; switch to the original material and don't move it anymore
            this.gameObject.GetComponent<MeshRenderer>().material = originalMaterial;
        }
    }
    
}
