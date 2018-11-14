using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Tweetinvi;
using Tweetinvi.Exceptions;
using Tweetinvi.Models;

namespace TestTwitter
{
   [Binding]
   public class Tests {

      public ITwitterCredentials __Credentials;
      
      [Given(@"a tweet was posted with text like this ""(.*)""")]
      public void SendTweet( string tweetText ) {
         try {
            __Credentials = TwitterAuth.GenerateCredentials();
         } catch( ArgumentException ex ) {
            Console.WriteLine("Request parameters are invalid: '{0}'", ex.Message);
         } catch( TwitterException ex ) {
            Console.WriteLine("Something went wrong when we tried to execute the http request : '{0}'", ex.TwitterDescription);
         }

         Auth.SetCredentials(__Credentials);
         ITweet tweet = Tweet.PublishTweet(tweetText);
         try {
            Assert.IsNotNull(tweet.Id);
         } catch {
            var latestException = ExceptionHandler.GetLastException();
            Console.WriteLine("The following error occured : '{0}', status: {1}", latestException.TwitterDescription, latestException.StatusCode);
         }
         
         ScenarioContext.Current.Add("TweetText", tweetText);
         ScenarioContext.Current.Add("TweetId", tweet.Id);
      }
      
      [Then(@"the tweet should be posted with that text")]
      public void VerifyTweet() {
         Auth.SetCredentials(__Credentials);
         long tweetId = (long)ScenarioContext.Current["TweetId"];
         string tweetText = (string)ScenarioContext.Current["TweetText"];
         ITweet tweet = Tweet.GetTweet(tweetId);
         Assert.AreEqual(tweetText, tweet.Text);
      }
   }
}
