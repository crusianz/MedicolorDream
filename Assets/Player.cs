using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float x = 0;
    bool run = false;
    Animator anime;
    [SerializeField]
    float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        run = Input.GetKey(KeyCode.LeftShift);

        if (run) speed = 20;
        else speed = 5;

        Vector3 velocity = new Vector3(x * speed * Time.deltaTime, 0);

        if(x > 0 || x < 0)
        {
            anime.SetBool("Walking",true);
            anime.SetBool("Running", run);
            transform.localScale = new Vector3(0.4f * x,0.4f);
            transform.Translate(velocity);
        }
        else
        {
            anime.SetBool("Walking", false);
            anime.SetBool("Running", false);
        }
    }
}
