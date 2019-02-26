using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testTask.Configure;
using testTask.Interfaces;
using Tweetinvi;

namespace testTask.Services
{
    public class TwitterAPIService : ITwitterAPIService
    {
        private readonly IOptions<TwitterOptions> _twitterOptions;

        public TwitterAPIService(IOptions<TwitterOptions> twitterOptions)
        {
            _twitterOptions = twitterOptions;
        }

        public void MakeTwitt(string message)
        {
            Auth.SetUserCredentials(_twitterOptions.Value.ConsumerKey, _twitterOptions.Value.ConsumerSecret, 
                _twitterOptions.Value.AccessToken, _twitterOptions.Value.AccessTokenSecret);
            Tweet.PublishTweet(message);
        }

        public Task MakeTwittAsync(string message)
        {
            return Task.Run(() => MakeTwitt(message));
        }

        public Task SendInformationAsync(string message)
        {
            return MakeTwittAsync(message);
        }
    }
}
