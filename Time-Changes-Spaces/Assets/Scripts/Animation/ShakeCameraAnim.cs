using UnityEngine;

public class ShakeCameraAnim : MonoBehaviour
{
    [SerializeField]
    private Player.Brain playerBrain;

    [SerializeField]
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
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

    private void AllowShake(bool canMove)
    {
        if (!canMove)
        {
            anim.SetTrigger("Shake");
        }
    }

    // Update is called once per frame
}
