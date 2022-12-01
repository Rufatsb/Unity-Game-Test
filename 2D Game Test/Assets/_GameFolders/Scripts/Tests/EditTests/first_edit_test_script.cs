using NUnit.Framework;


public class first_edit_test_script
{
    //Edit mode test//
    [Test]
    public void number1_and_number2_value_plus_result_equal_30()
    {
        //Arrange

        int number1 = 20;
        int number2 = 10;
        int expectedResult = 30;

        //Act
        int result = number1 + number2;

        //Assert

        Assert.AreEqual(expectedResult,actual:result);
        
      
    }

   
}
