using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NoteWebApp.Models;

namespace NoteWebApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return RedirectToAction("List");
		}

		public ActionResult List()
		{
			List<Note> noteList = NoteManager.GetNoteList();

			ViewBag.noteList = noteList;

			return View();
		}

		public ActionResult Detail(int id)
		{
			Note note = NoteManager.GetNoteById(id);

			if (note == null)
			{
				return View("Error");
			}

			ViewBag.note = note;

			return View();
		}

		[HttpPost]
		public ActionResult Update(int noteId, string title, string contents)
		{
			NoteManager.UpdateNote(noteId, title, contents);

			return RedirectToAction("Detail", new { id = noteId });
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Insert(string title, string contents)
		{
			int noteId = NoteManager.CreateNote(title, contents);

			return RedirectToAction("Detail", new { id = noteId });
		}

		[HttpPost]
		public ActionResult Delete(string noteId)
		{
			NoteManager.DeleteNote(noteId);

			return RedirectToAction("List");
		}
	}
}