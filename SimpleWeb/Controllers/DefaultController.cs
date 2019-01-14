using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleWeb.Models;

namespace SimpleWeb.Controllers
{
	public class DefaultController : Controller
	{
		public static List<Widget> widgets;

		public ActionResult Index()
		{
			PopulateWidgets();

			var catalog = new Catalog
			{
				Widgets = widgets
			};

			return View(catalog);
		}

		[HttpPost]
		public ActionResult Index(string description)
		{
			if (widgets == null)
				widgets = new List<Widget>();

			widgets.Add(new Widget
			{
				Id = new Guid(),
				Description = description
			});

			var catalog = new Catalog
			{
				Widgets = widgets
			};

			return View(catalog);
		}

		[HttpPost]
		public ActionResult Delete(Guid id)
		{
			if (widgets.Any(w => w.Id == id) == false)
				return Json(false);

			widgets.Remove(widgets.First(w => w.Id == id));
            return Json(true);
			//return new EmptyResult();
		}


		private void PopulateWidgets()
		{
			if (widgets != null)
				return;

			widgets = new List<Widget> { 
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "SCRAM Bracelet"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "Battery Faceplate Kit"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "Direct Connect"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "Strap Replacement Kit"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "Remote Breath Battery"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "GPS Bracelet"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "Multiconnect"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "Remote Breath Kit"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "Bubba Strap Kit"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "FedEx Shipping Label"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "GPS Bracelet Strap Kit"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "GPS Repeater"
				},
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "Bracelet Cleaning Kit"
				}
				,
				new Widget
				{
					Id = Guid.NewGuid(),
					Description = "20 Pack of Magnets"
				}
			};
		}

	}
}
