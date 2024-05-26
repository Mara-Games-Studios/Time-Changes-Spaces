using UnityEngine;

namespace Assets.Scripts.Global
{
    public class MaterialReset : MonoBehaviour
    {
        [SerializeField]
        private Material screenMaterial;

        private const string infectivity_string = "_intensity";
        private const string alfa_string = "_alfa";
        private float intensity = 0f;
        private float alfa = 0f;

        private void Start()
        {
            screenMaterial.SetFloat(infectivity_string, intensity);
            screenMaterial.SetFloat(alfa_string, alfa);
        }
    }
}
