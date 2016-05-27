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
        public void TestGetAttributeOfEnum()
        {
            Assert.IsNull(ReflectionHelper.GetAttributeOfEnum<Attributes.DescriptionAttribute, MyEnum>(MyEnum.NoAttribute));
            Assert.IsInstanceOfType(ReflectionHelper.GetAttributeOfEnum<Attributes.DescriptionAttribute, MyEnum>(MyEnum.WithAttribute), typeof(Attributes.DescriptionAttribute));

            var myModel = new MyModel {EnumProperty = MyEnum.WithAttribute};
            Assert.IsNotNull(ReflectionHelper.GetAttributeOfEnum<Attributes.DescriptionAttribute, MyEnum>(myModel.EnumProperty));
            Assert.IsInstanceOfType(ReflectionHelper.GetAttributeOfEnum<Attributes.DescriptionAttribute, MyEnum>(myModel.EnumProperty), typeof(Attributes.DescriptionAttribute));
        }

        [TestMethod]
        public void TestGetAttribute()
        {
            var myModel = new MyModel();
            Assert.IsNull(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute>(() => myModel.NoAttribute));
            Assert.IsInstanceOfType(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute>(() => myModel.WithAttribute), typeof(Attributes.DescriptionAttribute));

            myModel.WithAttribute = "hallo welt";
            Assert.IsInstanceOfType(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute>(() => myModel.WithAttribute), typeof(Attributes.DescriptionAttribute));

            myModel = new MyModel();
            Assert.IsNull(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute>(() => myModel.FieldNoAttribute));
            Assert.IsInstanceOfType(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute>(() => myModel.FieldWithAttribute), typeof(Attributes.DescriptionAttribute));

            myModel.FieldWithAttribute = "hallo welt";
            Assert.IsInstanceOfType(ReflectionHelper.GetAttribute<Attributes.DescriptionAttribute>(() => myModel.FieldWithAttribute), typeof(Attributes.DescriptionAttribute));
        }

        [TestMethod]
        public void TestGetAttributeOfField()
        {
            var myModel = new MyModel();
            Assert.IsNull(ReflectionHelper.GetAttributeOfField<Attributes.DescriptionAttribute>(() => myModel.NoAttribute));
            Assert.IsNull(ReflectionHelper.GetAttributeOfField<Attributes.DescriptionAttribute>(() => myModel.WithAttribute));

            myModel.WithAttribute = "hallo welt";
            Assert.IsNull(ReflectionHelper.GetAttributeOfField<Attributes.DescriptionAttribute>(() => myModel.WithAttribute));

            myModel = new MyModel();
            Assert.IsNull(ReflectionHelper.GetAttributeOfField<Attributes.DescriptionAttribute>(() => myModel.FieldNoAttribute));
            Assert.IsInstanceOfType(ReflectionHelper.GetAttributeOfField<Attributes.DescriptionAttribute>(() => myModel.FieldWithAttribute), typeof(Attributes.DescriptionAttribute));

            myModel.FieldWithAttribute = "hallo welt";
            Assert.IsInstanceOfType(ReflectionHelper.GetAttributeOfField<Attributes.DescriptionAttribute>(() => myModel.FieldWithAttribute), typeof(Attributes.DescriptionAttribute));
        }

        [TestMethod]
        public void TestGetAttributeOfProperty()
        {
            var myModel = new MyModel();
            Assert.IsNull(ReflectionHelper.GetAttributeOfProperty<Attributes.DescriptionAttribute>(() => myModel.NoAttribute));
            Assert.IsInstanceOfType(ReflectionHelper.GetAttributeOfProperty<Attributes.DescriptionAttribute>(() => myModel.WithAttribute), typeof(Attributes.DescriptionAttribute));

            myModel.WithAttribute = "hallo welt";
            Assert.IsInstanceOfType(ReflectionHelper.GetAttributeOfProperty<Attributes.DescriptionAttribute>(() => myModel.WithAttribute), typeof(Attributes.DescriptionAttribute));

            myModel = new MyModel();
            Assert.IsNull(ReflectionHelper.GetAttributeOfProperty<Attributes.DescriptionAttribute>(() => myModel.FieldNoAttribute));
            Assert.IsNull(ReflectionHelper.GetAttributeOfProperty<Attributes.DescriptionAttribute>(() => myModel.FieldWithAttribute));

            myModel.FieldWithAttribute = "hallo welt";
            Assert.IsNull(ReflectionHelper.GetAttributeOfProperty<Attributes.DescriptionAttribute>(() => myModel.FieldWithAttribute));
        }

        [TestMethod]
        public void TestGetAttributeOfMethod()
        {
            var myModel = new MyModel();
            Assert.IsNull(ReflectionHelper.GetAttributeOfMethod<Attributes.DescriptionAttribute>(() => myModel.MethodNoAttribute()));
            Assert.IsInstanceOfType(ReflectionHelper.GetAttributeOfMethod<Attributes.DescriptionAttribute>(() => myModel.MethodWithAttribute()), typeof(Attributes.DescriptionAttribute));
        }
    }
}
