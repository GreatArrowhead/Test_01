using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] Transform cockpit;

    [SerializeField] Transform muzzleStartTF;
    [SerializeField] Transform muzzleEndTF;

    [SerializeField] float shootForce;

    [SerializeField] GameObject canonballPrefab;
    GameObject canonball;

    Vector3 velocity;
    [SerializeField] float moveSpeed;

    Vector3 rotVector;
    [SerializeField] float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            FireCanon();

        Movement();
        Rotate();
    }

    void FireCanon()
    {
        canonball = Instantiate(canonballPrefab, muzzleEndTF.position, Quaternion.identity);

        Vector3 shootDirection = (muzzleEndTF.position - muzzleStartTF.position).normalized;

        canonball.GetComponent<Rigidbody>().AddForce(shootDirection * shootForce);

        Destroy(canonball, 4);
    }

    void Movement()
    {
        //velocityZ = Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        //velocityX = Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //transform.Translate(velocityZ + velocityX);

        velocity = ((Vector3.forward * Input.GetAxisRaw("Vertical")
            + Vector3.right * Input.GetAxisRaw("Horizontal")).normalized
            * Time.deltaTime * moveSpeed);

        transform.Translate(velocity);
    }

    void Rotate()
    {
        rotVector = Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed;
        cockpit.Rotate(rotVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            UIManager.Instance.AddScore(1);

            Destroy(other.gameObject);
        }
    }
}
