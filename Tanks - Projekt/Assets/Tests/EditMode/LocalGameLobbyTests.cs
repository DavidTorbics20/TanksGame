using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class LocalGameLobbyTests
{
    [Test]
    public void NameInputTest()
    {
        var player = new GameObject().AddComponent<LocalGameCanvasController>();
        string nameOne = "testOne";
        string nameTwo = "testTwo";
        
        bool success = player.CheckIfFilled(nameOne, nameTwo);
        Assert.IsTrue(success, "could not start game");
    }

    //[Test]    
    //public void 
}