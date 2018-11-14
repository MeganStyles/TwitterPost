Feature: Twitter feature
	In order to ensure text is displayed on twitter
	As a tweeter
	I want to see that my tweet text matches the tweet Id


Scenario: Send a tweet
   Given a tweet was posted with text like this "twitter3"
	Then the tweet should be posted with that text
