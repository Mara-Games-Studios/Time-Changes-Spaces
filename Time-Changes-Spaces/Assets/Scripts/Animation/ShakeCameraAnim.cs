using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCameraAnim : MonoBehaviour
{
    [SerializeField]
    private Player.Brain playerBrain;

    [SerializeField]
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    private void OnEnable()
    {
        playerBrain.OnTryMove += AllowShake;
    }

    private void OnDisable()
    {
        playerBrain.OnTryMove -= AllowShake;
    }

    void AllowShake(bool canMove)
    {
        if(!canMove)
            anim.SetTrigger("Shake");
    }

    // Update is called once per frame
    

}
