using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweetinvi;
using Tweetinvi.Models;

namespace TestTwitter
{
   [TestClass]
   public class Tests {

      public ITwitterCredentials __Credentials;
      //needs to be changed each time as twitter refuses two identical tweets in a row.
      public string __Tweet = "Hi BePure!";

      [TestMethod]
      public void SendTweet( ) {
         __Credentials = TwitterAuth.GenerateCredentials();
         Auth.SetCredentials(__Credentials);
         var tweet = Tweet.PublishTweet(__Tweet);

         Assert.IsNotNull(tweet.Id);
         VerifyTweet(tweet.Id);
      }
      

      public void VerifyTweet( long tweetId ) {
         var tweet = Tweet.GetTweet(tweetId);
         Assert.AreEqual(__Tweet, tweet.Text);
      }
   }
}
