using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int score = 0;

    // public Camera camera;

    // public GameObject camera;

    public Button button;

    public GameObject cameraOne;
    public GameObject cameraTwo;

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        /*
        var camera = this.camera.GetComponent<Camera>();

        this.camera.GetComponent<Camera>();

        var camera = this.GetComponent<Transform>()
            .GetChild(0)
            .gameObject
            .GetComponent<Camera>();
        
        var camera = GameObject.Find("Camera").GetComponent<Camera>();
        */

        this.button.onClick.AddListener(this.cameraChangeCounter);
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(
            this.transform.position,
            new Vector3(0.0f, 0.0f, 1.0f)
            );
        // RaycastHit hit = Physics.Raycast(ray, hit);
        RaycastHit hit;
        if (Physics.Raycast(ray,
        out hit,
        Mathf.Infinity,
        LayerMask.GetMask(new string[] { "Interactive" }
        )))
        {
            Debug.Log(hit);
            var transform = hit.collider.gameObject.GetComponent<Transform>();
            transform.localScale *= 1.01f;
        }

        /*
        var transform = this.GetComponent<Transform>();
        var position = transform.position;
        position.x += this.speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        position.z += this.speed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position = position;
        */

        var characterController = this.GetComponent<CharacterController>();
        characterController.SimpleMove(new Vector3(
            this.speed * Input.GetAxis("Horizontal"),
            0.0f,
            this.speed * Input.GetAxis("Vertical")
            ));
    }

    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }
        PlayerPrefs.SetInt("CameraPosition", camPosition);
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraTwo.SetActive(false);
        }
        if (camPosition == 1)
        {
            cameraTwo.SetActive(true);
            cameraOne.SetActive(false);
        }
    }
}