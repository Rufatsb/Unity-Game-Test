using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class first_play_mode_test_script
{
   
    [UnityTest]
    [CanBeNull]
    public IEnumerator create_new_game_object_and_find_on_scene()
    {
        //Arrange
        string name = "NewObject";

        GameObject gameObject = new GameObject(name);

        //Act
        yield return new WaitForSeconds(1);
        GameObject findObject = GameObject.Find(name);
        yield return new WaitForSeconds(1);

        //Assert
        Assert.AreEqual(gameObject, findObject);



        yield return null;
    }
}
