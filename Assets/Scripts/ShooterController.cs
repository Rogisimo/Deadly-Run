using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class ShooterController : MonoBehaviour
{
    public List<GameObject> shooters; // List of all shooters
    public TextMeshProUGUI timerText; // UI Text to display the timer
    private float gameTimer = 0f; // Game timer
    private float shootInterval = 10f; // Interval between shots, will be adjusted based on difficulty
    private float lastShootTime = 0f; // The last time shooters fired

    void Start()
    {
        StartCoroutine(UpdateTimer());
        Shoot();
    }

    void Update()
    {
        gameTimer += Time.deltaTime;

        // Update the timer display
        timerText.text = gameTimer.ToString("F2");

        // Check if it's time for some shooters to shoot
        if (gameTimer - lastShootTime > shootInterval)
        {
            Shoot();
            lastShootTime = gameTimer;
        }

        // Adjust difficulty based on elapsed time
        AdjustDifficulty();
    }

    void Shoot()
    {
        // Determine how many shooters should shoot based on the current difficulty
        int shootersToShoot = Mathf.FloorToInt(shooters.Count * GetCurrentShooterPercentage());

        // Randomly pick shooters to shoot
        foreach (var shooter in shooters.OrderBy(x => Random.value).Take(shootersToShoot))
        {
            // Implement shooting mechanism here, for example:
            StartCoroutine(StartShooting(shooter.GetComponent<Shooter>()));
        }
    }

    IEnumerator StartShooting(Shooter shooter){
        float randomWaitTime = Random.Range(0.5f,1.5f);
        yield return new WaitForSeconds(randomWaitTime);
        shooter.Shoot();
        yield break;
    }

    float GetCurrentShooterPercentage()
    {
        if (gameTimer < 30f) // Very Easy
            return 0.1f;
        else if (gameTimer < 60f) // Easy
            return 0.2f;
        else if (gameTimer < 120f) // Medium
            return 0.35f;
        else // Hard
            return 0.5f;
    }

    void AdjustDifficulty()
    {
        if (gameTimer < 30f) // Very Easy
            shootInterval = 6f; // Slower shooting
        else if (gameTimer < 60f) // Easy
            shootInterval = 5f; // A bit faster
        else if (gameTimer < 120f) // Medium
            shootInterval = 4f; // Normal speed
        else // Hard
            shootInterval = 3f; // Fast shooting
    }

    IEnumerator UpdateTimer()
    {
        while (true)
        {
            timerText.text = gameTimer.ToString("F2");
            yield return new WaitForSeconds(0.1f);
        }
    }
}
