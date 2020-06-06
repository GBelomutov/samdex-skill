using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System.Threading.Tasks;

namespace AP.Constantine.Functions.Authentication
{
    public interface IAuthenticationProvider
    {
        Task<GetUserResponse> GetUser(string accessToken);
    }

    public class AuthenticationProvider : IAuthenticationProvider
    {
#pragma warning disable CS1998 // Warning caused by preprocessor directives. Not relevant in release code
        public async Task<GetUserResponse> GetUser(string accessToken)
#pragma warning restore CS1998 // Warning caused by preprocessor directives. Not relevant in release code
        {
            var request = new GetUserRequest
            {
                AccessToken = accessToken,
            };

#if DEBUG
            return new GetUserResponse { Username = $"DEBUG USER: {accessToken}" };
#else
            using var client = new AmazonCognitoIdentityProviderClient();
            var user = await client.GetUserAsync(request);
            return user;
#endif
        }
    }
}
