//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Threading.Tasks;

//namespace LasrraAMPService.Services
//{
//    public class JWTService
//    {
//        public object DecodeJWT(string Token)
//        {
           
//            TokenValidationParameters tokenVal = new TokenValidationParameters();

//            //  tokenVal.IssuerSigningKey = "sdfQyeyfgkjujb12";
          
            
            
//            //tokenVal.
//            var handler = new JwtSecurityTokenHandler();
//            var decodedValue = handler.ReadJwtToken(Token);
//           //var decodedValue1 = handler.ValidateToken(Token);
//            return decodedValue;

//        }

//        public object EncodeJWT(object data)
//        {
//            var handler = new JwtSecurityTokenHandler();
//            var s = new SecurityTokenDescriptor();
//            s.Audience = ""; // do the others before creating the token to be returned
//             var decodedValue = handler.CreateEncodedJwt(s);
//            return decodedValue;

//        }
//    }
//}
