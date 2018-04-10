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

				String sql = "select * from Note order by createddate desc";

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

		internal static void UpdateNote(int noteId, string title, string contents)
		{
			using (OracleConnection conn = new OracleConnection(_connectionString))
			{
				conn.Open();

				String sql = $"update NOTE set title = '{title}', contents = '{contents}' where noteid = {noteId}";

				OracleCommand cmd = new OracleCommand
				{
					Connection = conn,
					CommandText = sql
				};

				cmd.ExecuteNonQuery();
			}
		}

		internal static void DeleteNote(string noteId)
		{
			using (OracleConnection conn = new OracleConnection(_connectionString))
			{
				conn.Open();

				String sql = $"delete from note where noteid = {noteId}";

				OracleCommand cmd = new OracleCommand
				{
					Connection = conn,
					CommandText = sql
				};

				cmd.ExecuteNonQuery();
			}
		}

		internal static int CreateNote(string title, string contents)
		{
			// 새 note id 구하기
			int newNoteId = FindNewNoteId();

			using (OracleConnection conn = new OracleConnection(_connectionString))
			{
				conn.Open();
				
				String sql = $"insert into note (noteid, title, contents, createddate) values ({newNoteId}, '{title}', '{contents}.', sysdate )";

				OracleCommand cmd = new OracleCommand
				{
					Connection = conn,
					CommandText = sql
				};

				cmd.ExecuteNonQuery();
			}

			return newNoteId;
		}

		private static int FindNewNoteId()
		{
			int newNoteId;

			using (OracleConnection conn = new OracleConnection(_connectionString))
			{
				conn.Open();

				String sql = "select note_seq.nextval from dual";

				OracleCommand cmd = new OracleCommand
				{
					Connection = conn,
					CommandText = sql
				};

				OracleDataReader reader = cmd.ExecuteReader();
				reader.Read();
				newNoteId = int.Parse(reader[0].ToString());

				reader.Close();
			}

			return newNoteId;
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