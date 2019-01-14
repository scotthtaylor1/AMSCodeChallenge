using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWeb.Controllers;
using SimpleWeb.Models;

namespace SimpleWeb.Tests
{
	[TestClass]
	public class DefaultIndexTests
	{
		[TestMethod]
		public void When_NewWidgetIsPosted_WidgetsCollectionContainsNewWidget()
		{
			var controller = new DefaultController();
			var description = "New Widget";

			controller.Index(description);

			Assert.IsTrue(DefaultController.widgets.Any(w => w.Description == "New Widget"));
		}


		[TestMethod]
		public void When_ExistingWidgetIsDeleted_DeleteReturnsEmptyResult()
		{
			var controller = new DefaultController();
			Widget widget;
			ActionResult result;

			controller.Index();
			widget = DefaultController.widgets.First();

			result = controller.Delete(widget.Id);

			//Assert.IsInstanceOfType(result, typeof(EmptyResult));
            Assert.IsTrue((bool)((JsonResult)result).Data);
        }

        [TestMethod]
		public void When_UnknwonWidgetIsDeleted_DeleteReturnsJsonFalse()
		{
			var controller = new DefaultController();
			var widget = new Widget { Id = Guid.NewGuid(), Description = "Unknown Widget"};
			ActionResult result;

			controller.Index();
			
			result = controller.Delete(widget.Id);

			Assert.IsInstanceOfType(result, typeof(JsonResult));
			Assert.IsFalse((bool) ((JsonResult)result).Data);
		}
	}
}
