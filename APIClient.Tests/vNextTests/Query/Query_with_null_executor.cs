﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static VersionOne.SDK.APIClient.Tests.vNextTests.Query.QueryTestBase;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Query
{
	[TestClass]
	public class Query_with_null_executor
	{
		private static Exception ExpectedException;

		[ClassInitialize]
		[ExpectedException(typeof(ArgumentNullException))]
		public static void Initialize(TestContext context)
		{
			try
			{
				ConfigureSUT(context, "Story", null, true);
			}
			catch (Exception ex)
			{
				ExpectedException = ex;
			}
		}

		[TestMethod]
		public void Exception_should_be_ArgumentNullException() =>
			Assert.IsInstanceOfType(ExpectedException, typeof(ArgumentNullException));

		[TestMethod]
		public void Exception_message() =>
			Assert.AreEqual("Value cannot be null.\r\nParameter name: executor", ExpectedException.Message);
	}
}