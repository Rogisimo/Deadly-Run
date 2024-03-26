using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab in the Unity Editor
    float shootingForce = 100f; // Adjust based on desired bullet speed

    public void Shoot()
    {
        if (bulletPrefab != null)
        {
            // Instantiate the bullet at the shooter's position and orientation
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // Assuming the bullet has a Rigidbody component to apply force for movement
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                // Apply force to the bullet in the direction the shooter is facing
                bulletRb.AddForce(transform.forward * shootingForce);
            }
        }
    }
}
