using System.Reflection;

namespace UserTesting.DAL.Tests;

// To be fair this code is not mine :)
// But I have modified it a little bit to suite my needs
public class ObjectComparer
{
	public void Compare(object? expectedObj, object? actualObj)
	{
		if (expectedObj is null && actualObj is null)
		{
			return;
		}

		if (expectedObj is null && actualObj is not null)
		{
			Assert.That(actualObj, Is.Null);
		}

		if (expectedObj is not null && actualObj is null)
		{
			Assert.That(actualObj, Is.Not.Null);
		}

		Type expectedType = expectedObj!.GetType();
		Type actualType = actualObj!.GetType();

		var expectedProperties = expectedType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
		var actualProperties = actualType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

		foreach (PropertyInfo expectedProperty in expectedProperties)
		{
			string expectedPropertyName = expectedProperty.Name;
			var expectedValue = expectedProperty.GetValue(expectedObj);

			var type2Property = Array.Find(actualProperties, p => string.Equals(p.Name, expectedPropertyName, StringComparison.Ordinal));

			Assert.That(type2Property, Is.Not.Null, $"obj2 has no '{expectedProperty.Name}' property");
			Assert.That(type2Property!.PropertyType, Is.EqualTo(expectedProperty.PropertyType), $"obj2 has property with different type");

			var actualValue = type2Property!.GetValue(actualObj);

			if (expectedProperty.PropertyType == typeof(long))
			{
				Assert.That(actualValue, Is.EqualTo(expectedValue), $"The {expectedPropertyName} property of the actualObj has the '{actualValue}', but the expectedObj has '{expectedValue}'.");
			}
			else if (expectedProperty.PropertyType == typeof(string))
			{
				Assert.That(actualValue, Is.EqualTo(expectedValue), $"The {expectedPropertyName} property of the actualObj has the '{actualValue}', but the expectedObj has '{expectedValue}'.");
			}
			else if (expectedProperty.PropertyType == typeof(DateTime))
			{
				Assert.That(actualValue, Is.EqualTo(expectedValue), $"The {expectedPropertyName} property of the actualObj has the '{actualValue}', but the expectedObj has '{expectedValue}'.");
			}
			else if (expectedProperty.PropertyType.IsGenericType)
			{
				continue;
			}
			else if (expectedProperty.PropertyType.IsClass)
			{
				Compare(expectedValue, actualValue);
			}
		}
	}
}
