using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Assignment5Webpage.Infrastructure
{
    //This is a tool to covert our Cart object to a Json (string) file and then back.
    //Because we can't store Carts in a session

    public static class SessionExtensions //class
    {
      public static void SetJson (this ISession session, string key, object value) //set method
      {
            session.SetString(key, JsonSerializer.Serialize(value));
      }

      public static T GetJson<T> (this ISession session, string key) //get method. <t> means Type
      {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
      }


    }
}
