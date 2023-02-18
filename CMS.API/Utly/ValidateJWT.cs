using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace CMS.API.Utly
{
    public class ValidateJWT
    {
        public bool IsValid { get; }
        public string UserEmail { get; }
        public string Role { get; }
        public ValidateJWT(HttpRequest request)
        {
            // Check if we have a header.
            if (!request.Headers.ContainsKey("Authorization"))
            {
                IsValid = false;
                return;
            }
            string authorizationHeader = request.Headers["Authorization"];
            // Check if the value is empty.
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                IsValid = false;
                return;
            }
            // Check if we can decode the header.
            IDictionary<string, object> claims = null;
            try
            {
                if (authorizationHeader.StartsWith("Bearer"))
                    authorizationHeader = authorizationHeader.Substring(7);

                // Validate the token and decode the claims.
                claims = new JwtBuilder()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret("eCommerenceSolutions@101")
                    .MustVerifySignature()
                    .Decode<IDictionary<string, object>>(authorizationHeader);
            }
            catch (Exception e)
            {
                IsValid = false;
                Console.WriteLine(e.StackTrace);
                return;
            }

            // Check if we have user claim.
            if (!claims.ContainsKey("UserEmail"))
            {
                IsValid = false;
                return;
            }

            IsValid = true;
            UserEmail = Convert.ToString(claims["UserEmail"]);
            Role = Convert.ToString(claims["Role"]);
        }
    }
}
