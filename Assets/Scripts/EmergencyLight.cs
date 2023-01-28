using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyLight : MonoBehaviour
{
    [SerializeField] private GameObject m_pointLight;
    [SerializeField] private Material m_unlitMaterial;
    [SerializeField] private Material m_litMaterial;

    private Renderer m_renderer;
    private bool m_isActive;

    private void Start()
    {
        m_isActive = true;
        m_renderer = GetComponent<Renderer>();
        StartCoroutine(FlashLight());
    }

    private IEnumerator FlashLight()
    {
        while (m_isActive)
        {
            m_pointLight.SetActive(false);
            m_renderer.material = m_unlitMaterial;
            yield return new WaitForSeconds(0.4f);
            Debug.Log("Change Colour");
            m_pointLight.SetActive(true);
            m_renderer.material = m_litMaterial;
            yield return new WaitForSeconds(0.4f);
        }

        yield return null;
    }
}
