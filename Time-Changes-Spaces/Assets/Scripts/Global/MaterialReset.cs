using UnityEngine;

namespace Assets.Scripts.Global
{
    public class MaterialReset : MonoBehaviour
    {

        [SerializeField]
        private Material screenMaterial;

        private const string infectivity_string = "_intencity";
        private const string alfa_string = "_alfa";
        // Use this for initialization
        private void Awake()
        {
            screenMaterial.SetFloat(infectivity_string, 0.0f);
            screenMaterial.SetFloat(alfa_string, 0.0f);
            Destroy(gameObject);
        }
    }
}