using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool;

    public float distanceBetweenCoins;

    /* generate coins starting from the center of the platform
     * 
     * 1:              O
     * 2:            O   O
     * 3:          O   O   O  
     * 4:        O   O   O   O
     */
    public void SpawnCoins(Vector3 startPosition, int numCoins)
    {
        if (numCoins < 1)
        {
            return;
        }

        int coinCount = numCoins;
        int index = 0;
        float offset = 0;         // for even numbered coin groups
        int flip = 1;             // place coins on left vs right side of center

        if (coinCount % 2 == 0)
        {
            offset = -0.5f;
            flip = -1;
        }

        while(coinCount > 0)
        {
            GameObject coin = coinPool.ActivatePoolObject();
            coin.transform.position = new Vector3(startPosition.x + distanceBetweenCoins * index * flip + offset, startPosition.y, startPosition.z);
            coin.SetActive(true);

            if (flip > 0)
            {
                index += 1;
            }

            offset *= -1; 
            coinCount -= 1; 
            flip *= -1; 
        }

    }
}
