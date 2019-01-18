using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.Test
{
	[TestClass]
	public class FinderTests
	{
		[TestMethod]
		public void Returns_Empty_Results_When_Given_Empty_List()
		{
            //Arrange
			var list = new List<Person>();
			var finder = new Finder(list);

            //Act
			var result = finder.Find(FindTypes.Closest);

            //Assert
			Assert.IsNull(result.Person1);
			Assert.IsNull(result.Person2);
		}

		[TestMethod]
		public void Returns_Empty_Results_When_Given_One_Person()
		{
            //Arrange
			var list = new List<Person>() { sue };
			var finder = new Finder(list);

            //Act
			var result = finder.Find(FindTypes.Closest);

            //Assert
			Assert.IsNull(result.Person1);
			Assert.IsNull(result.Person2);
		}

		[TestMethod]
		public void Returns_Closest_Two_For_Two_People()
		{
            //Arrange
			var list = new List<Person>() { sue, greg };
			var finder = new Finder(list);

            //Act
			var result = finder.Find(FindTypes.Closest);

            //Assert
			Assert.AreSame(sue, result.Person1);
			Assert.AreSame(greg, result.Person2);
		}

		[TestMethod]
		public void Returns_Furthest_Two_For_Two_People()
		{
            //Arrange
			var list = new List<Person>() { greg, mike };
			var finder = new Finder(list);

            //Act
			var result = finder.Find(FindTypes.Furthest);

            //Assert
			Assert.AreSame(greg, result.Person1);
			Assert.AreSame(mike, result.Person2);
		}

		[TestMethod]
		public void Returns_Furthest_Two_For_Four_People()
		{
            //Arrange
			var list = new List<Person>() { greg, mike, sarah, sue };
			var finder = new Finder(list);

            //Act
			var result = finder.Find(FindTypes.Furthest);

            //Assert
			Assert.AreSame(sue, result.Person1);
			Assert.AreSame(sarah, result.Person2);
		}

		[TestMethod]
		public void Returns_Closest_Two_For_Four_People()
		{
            //Arrange
			var list = new List<Person>() { greg, mike, sarah, sue };
			var finder = new Finder(list);

            //Act
			var result = finder.Find(FindTypes.Closest);

            //Assert
			Assert.AreSame(sue, result.Person1);
			Assert.AreSame(greg, result.Person2);
		}

		Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
		Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
		Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
		Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
	}
}