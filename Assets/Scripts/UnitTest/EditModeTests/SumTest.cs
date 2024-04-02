using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SumTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void SumSanityTest()
    {
        Assert.AreEqual(9, UnitTestEXP.Sum(2, 7));
    }
}
