using System;
using Famoser.FrameworkEssentials.Helpers;
using Famoser.FrameworkEssentials.Tests.Enums;
using Famoser.FrameworkEssentials.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Famoser.FrameworkEssentials.Tests
{
    [TestClass]
    public class TestReflectionHelper
    {
        [TestMethod]
        public void EnumTests()
        {
            Assert.IsNull(ReflectionHelper.GetAttributeFromEnum<Attributes.DescriptionAttribute, MyEnum>(MyEnum.NoAttribute));
            Assert.IsInstanceOfType(ReflectionHelper.GetAttributeFromEnum<Attributes.DescriptionAttribute, MyEnum>(MyEnum.WithAttribute), typeof(Attributes.DescriptionAttribute));
        }

        [TestMethod]
        public void ModelTests()
        {
            var myModel = new MyModel();
            Assert.IsNull(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute, MyModel>(() => myModel.NoAttribute));
            Assert.IsInstanceOfType(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute, MyModel>(() => myModel.WithAttribute), typeof(Attributes.DescriptionAttribute));

            myModel.WithAttribute = "hallo welt";
            Assert.IsInstanceOfType(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute, MyModel>(() => myModel.WithAttribute), typeof(Attributes.DescriptionAttribute));

            myModel = new MyModel();
            Assert.IsNull(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute, MyModel>(() => myModel.FieldNoAttribute));
            Assert.IsInstanceOfType(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute, MyModel>(() => myModel.FieldWithAttribute), typeof(Attributes.DescriptionAttribute));

            myModel.FieldWithAttribute = "hallo welt";
            Assert.IsInstanceOfType(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute, MyModel>(() => myModel.FieldWithAttribute), typeof(Attributes.DescriptionAttribute));

        }
    }
}
