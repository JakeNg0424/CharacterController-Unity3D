using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{

    bool wasPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var transform = GetComponent<Transform>();
        transform.rotation *= Quaternion.Euler(0.0f, 100.0f * Time.deltaTime, 0.0f);

        if (this.wasPickedUp)
        {
            transform.localScale *= 0.95f;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // if (collider.gameObject.GetComponent<Player>() != null) {}
        if (!this.wasPickedUp)
        {
            var player = collider.gameObject.GetComponent<Player>();
            //if (player != null) {
            Debug.Log("Something collided with us!");
            ScoringSystem.theScore += 1;
            Object.Destroy(this.gameObject, 0.5f);
            this.wasPickedUp = true;

            player.score += 1;
            var text = GameObject.Find("Score Text").GetComponent<Text>();
            text.text = "Hello";
            //}
        }
    
        AddInt(1, 2);
        AddFloat(1.5f, 2.5f);

        this.LogStuff();
    }

    int AddInt(int a, int b)
    {
        return a + b;
    }

    float AddFloat(float a, float b)
    {
        return a + b;
    }

    void LogStuff(string message = "hello")
    {
        Debug.Log(message);
    }
}
