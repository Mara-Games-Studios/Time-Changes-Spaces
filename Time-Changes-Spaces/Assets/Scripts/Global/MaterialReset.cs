using UnityEngine;

namespace Assets.Scripts.Global
{
    public class MaterialReset : MonoBehaviour
    {
        [SerializeField]
        private Material screenMaterial;

        private const string infectivity_string = "_intensity";
        private const string alfa_string = "_alfa";
        private float intensity = 1.0f;
        private float alfa = 1.0f;
        private float timer = 0.0f;

        private void Update()
        {
            SlowWhiteFade();
        }

        private void SlowWhiteFade()
        {
            if (intensity > 0.1f)
            {
                timer += Time.deltaTime * 0.3f;
                intensity = Mathf.Lerp(intensity, 0.0f, timer);
                alfa = Mathf.Lerp(alfa, 0.0f, timer);

                screenMaterial.SetFloat(infectivity_string, intensity);
                screenMaterial.SetFloat(alfa_string, alfa);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
