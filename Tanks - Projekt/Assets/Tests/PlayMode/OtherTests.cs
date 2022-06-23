using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OtherTests
{
    [UnityTest]
    public IEnumerator BulletMovement()
    {
        Rigidbody2D rb;
        var bullet = new GameObject().AddComponent<BulletControl>();
        bullet.GetComponent<Rigidbody2D>();

        bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector3 bullet_position = bullet.transform.position;
        yield return new WaitForSecondsRealtime(0.1f);
        Vector3 new_bullet_position = bullet.transform.position;
        Assert.Greater(new_bullet_position.y, bullet_position.y, "Bullet movement error");
    }
}
