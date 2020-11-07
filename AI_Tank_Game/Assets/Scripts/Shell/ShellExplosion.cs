using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public ParticleSystem m_ExplosionParticles;
    public float m_MaxLifeTime = 2f;           

    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
        m_ExplosionParticles.Play();
    }
}