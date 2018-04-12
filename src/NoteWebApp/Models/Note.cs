using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteWebApp.Models
{
	public class Note
	{
		public int? NoteId;
		public string Title;
		public string Contents;

		public Note()
		{
			this.NoteId = null;
			this.Title = "";
			this.Contents = "";
		}
	}
}