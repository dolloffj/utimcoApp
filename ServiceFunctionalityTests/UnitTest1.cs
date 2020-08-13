using System;
using Xunit;
using Newtonsoft.Json;
using System.IO;
using MenuService.Services;
using MenuService.Models;
using System.Collections.Generic;

namespace ServiceFunctionalityTests
{  
    public class UnitTest1
    {
        public static readonly string testFilePath = ".\\TestFiles\\menuArray.txt";

        [Fact]
        public void TestSumArrayValues()
        {
            int[] answerArray = { 46, 0 , 248};
            var idSums = new List<int>();
            var Menus = Operations.GetMenuListFromFile(testFilePath);
            foreach (MenuContainer m in Menus)
            {
                var sum = Operations.ComputeMenuIdSum(m.MenuObject);
                idSums.Add(sum);
            }

            for(int i = 0; i < answerArray.Length; i++)
            {
                Assert.Equal(answerArray[i], idSums[i]);
            }
        }
    }
}

