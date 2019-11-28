using System;
using System.IO;
using Android.Content;
using DotaAnalyst.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace DotaAnalyst.Droid
{
    class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            if (!File.Exists(path))
            {
                Context context = Android.App.Application.Context;
                var dbAssetStream = context.Assets.Open(sqliteFilename);

                var dbFileStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
                var buffer = new byte[1024];

                int b = buffer.Length;
                int length;

                while ((length = dbAssetStream.Read(buffer, 0, b)) > 0)
                {
                    dbFileStream.Write(buffer, 0, length);
                }

                dbFileStream.Flush();
                dbFileStream.Close();
                dbAssetStream.Close();
            }

            return path;
        }
    }
}