﻿using System;
using System.Collections.Generic;
using System.Text;
using TestHouse.Domain.Models;
using Xunit;

namespace TestHouse.Domain.Tests.Models
{
    public class TestCaseRunHistoryTests
    {
        [Fact]
        public void Creation()
        {
            var project = new Project("name", "description");
            var suit = new Suit("name", "description",0,project);
            var testCase = new TestCase("name", "description", "expectedResult", suit, 0);
            var testRun = new TestRun("name", "description", project,new List<TestCaseRun>());
            var testCaseRun = new TestCaseRun(testCase, null, testRun);
            var testHistory = new TestCaseRunHistory(Enums.RunHistoryType.Status, "message", testCaseRun);

            Assert.NotNull(suit);
            Assert.NotNull(project);
            Assert.NotNull(testCase);
            Assert.NotNull(testCaseRun);
            Assert.NotNull(testRun);
            Assert.NotNull(testHistory);

            Assert.Throws<ArgumentException>(() => new TestCaseRunHistory(Enums.RunHistoryType.Status, "", testCaseRun));
            Assert.Throws<ArgumentException>(() => new TestCaseRunHistory(Enums.RunHistoryType.Status, "message", null));            
        }
    }
}
