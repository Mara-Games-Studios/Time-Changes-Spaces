using UnityEngine;

namespace Assets.Scripts.Global
{
    public class MaterialReset : MonoBehaviour
    {

        [SerializeField]
        private Material screenMaterial;

        private const string infectivity_string = "_intencity";
        private const string alfa_string = "_alfa";
        private float intencity = 1.0f;
        private float alfa = 1.0f;

        private float t = 0.0f;
        // Use this for initialization
        private void Awake()
        {
            screenMaterial.SetFloat(infectivity_string, 1.0f);
            screenMaterial.SetFloat(alfa_string, 1.0f);
            //Destroy(gameObject);
        }

        private void Update()
        {
            SlowWhiteFade();
        }

        private void SlowWhiteFade()
        {
            if (intencity > 0.1f)
            {
                t += Time.deltaTime * 0.3f;
                intencity = Mathf.Lerp(intencity, 0.0f, t);
                alfa = Mathf.Lerp(alfa, 0.0f, t);

                screenMaterial.SetFloat(infectivity_string, intencity);
                screenMaterial.SetFloat(alfa_string, alfa);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}