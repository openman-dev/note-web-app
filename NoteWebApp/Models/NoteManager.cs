using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace NoteWebApp.Models
{
	public class NoteManager
	{
		static String _connectionString = "DATA SOURCE = xe; User Id = Note; Password = note";

		internal static List<Note> GetNoteList()
		{
			List<Note> noteList = new List<Note>();

			using (OracleConnection conn = new OracleConnection(_connectionString))
			{
				conn.Open();

				String sql = "select * from Note";

				OracleCommand cmd = new OracleCommand
				{
					Connection = conn,
					CommandText = sql
				};

				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Note note = new Note();

					note.NoteId = int.Parse( reader["noteid"].ToString() );
					note.Title = reader["title"] as string;
					note.Contents = reader["contents"] as string;

					noteList.Add(note);
				}

				reader.Close();
			}

			return noteList;
		}

		internal static Note GetNoteById(int id)
		{
			Note note = null;

			using (OracleConnection conn = new OracleConnection(_connectionString))
			{
				conn.Open();

				String sql = "select * from note where noteid = " + id.ToString();

				OracleCommand cmd = new OracleCommand
				{
					Connection = conn,
					CommandText = sql
				};

				OracleDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					note = new Note();

					note.NoteId = int.Parse(reader["noteid"].ToString());
					note.Title = reader["title"] as string;
					note.Contents = reader["contents"] as string;
				}

				reader.Close();
			}

			return note;
		}
	}
}