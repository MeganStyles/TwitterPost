using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Exceptions;
using Tweetinvi.Models;

namespace TestTwitter
{
   public static class TwitterAuth
   {
      public static string __ConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
      public static string __ConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];
      public static string __AccessToken = ConfigurationManager.AppSettings["TwitterAuthorisationToken"];
      public static string __AccessTokenSecret = ConfigurationManager.AppSettings["TwitterAuthSecret"];

      public static ITwitterCredentials GenerateCredentials() {
          return new TwitterCredentials(__ConsumerKey, __ConsumerSecret, __AccessToken, __AccessTokenSecret);
      } 
   }
}
