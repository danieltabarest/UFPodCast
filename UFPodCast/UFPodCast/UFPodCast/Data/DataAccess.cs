
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using UFPodCast.Interfaces;
using UFPodCast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;


namespace UFPodCast
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

          public DataAccess()
          {
              var config = DependencyService.Get<IConfig>();
              connection = new SQLiteConnection(config.Platform,
                  System.IO.Path.Combine(config.DirectoryDB, "UfPodCast.db3"));

              connection.CreateTable<Parameter>();
              
          }

          public void Insert<T>(T model)
          {
              connection.Insert(model);
          }

          public void Update<T>(T model)
          {
              connection.Update(model);
          }

          public void Delete<T>(T model)
          {
              connection.Delete(model);
          }

          public T First<T>(bool WithChildren) where T : class
          {
              if (WithChildren)
              {
                  return connection.GetAllWithChildren<T>().FirstOrDefault();
              }
              else
              {
                  return connection.Table<T>().FirstOrDefault();
              }
          }

          public List<T> GetList<T>(bool WithChildren) where T : class
          {
              if (WithChildren)
              {
                  return connection.GetAllWithChildren<T>().ToList();
              }
              else
              {
                  return connection.Table<T>().ToList();
              }
          }

          public T Find<T>(int pk, bool WithChildren) where T : class
          {
              if (WithChildren)
              {
                  return connection.GetAllWithChildren<T>().FirstOrDefault(m => m.GetHashCode() == pk);
              }
              else
              {
                  return connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk);
              }
          }

        public void Dispose()
        {
            connection.Dispose();
        }
    }

}

