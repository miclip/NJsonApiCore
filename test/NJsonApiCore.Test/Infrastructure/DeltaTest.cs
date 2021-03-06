﻿using System.Collections.Generic;
using NJsonApi.Infrastructure;
using Xunit;

namespace NJsonApi.Test.Infrastructure
{
    public class DeltaTest
    {
        [Fact]
        public void SimpleTestOfFunction()
        {
            //Arange
            var simpleObject = new SimpleTestClass();
            var classUnderTest = new Delta<SimpleTestClass>();

            classUnderTest.FilterOut(t => t.Prop1NotIncluded);
            classUnderTest.ObjectPropertyValues = new Dictionary<string, object>()
                                         {
                                           {"Prop2","b"}
                                         };
            //Act
            classUnderTest.ApplySimpleProperties(simpleObject);

            //Assert
            Assert.NotNull(simpleObject.Prop2);
            Assert.Equal(simpleObject.Prop2, "b");
            Assert.Null(simpleObject.Prop1NotIncluded);
        }

        [Fact]
        public void TestNotIncludedProperties()
        {
            //Arrange
            var simpleObject = new SimpleTestClass();
            var objectUnderTest = new Delta<SimpleTestClass>();

            objectUnderTest.FilterOut(t => t.Prop1NotIncluded);
            objectUnderTest.ObjectPropertyValues = new Dictionary<string, object>()
                                         {
                                           {"Prop2","b"},
                                           {"Prop1NotIncluded",5} 
                                         };
            //Act
            objectUnderTest.ApplySimpleProperties(simpleObject);

            //Assert
            Assert.NotNull(simpleObject.Prop2);
            Assert.Equal(simpleObject.Prop2, "b");
            Assert.Null(simpleObject.Prop1NotIncluded);
        }

        [Fact]
        public void TestEmptyPropertiesValues()
        {
            //Arrange
            var simpleObject = new SimpleTestClass();
            var objectUnderTest = new Delta<SimpleTestClass>();

            //Act
            objectUnderTest.FilterOut(t => t.Prop1NotIncluded);
            objectUnderTest.ApplySimpleProperties(simpleObject);

            //Assert
            Assert.Null(simpleObject.Prop1NotIncluded);
            Assert.Null(simpleObject.Prop1);
            Assert.Null(simpleObject.Prop2);
        }
    }

    internal class SimpleTestClass
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public int? Prop1NotIncluded { get; set; }
    }
    internal class SecondSimpleTestClass
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public int Prop1NotIncluded { get; set; }
    }
}
