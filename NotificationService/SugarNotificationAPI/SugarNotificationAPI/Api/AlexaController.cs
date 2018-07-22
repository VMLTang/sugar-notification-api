using SugarNotificationAPI.Handlers;
using SugarNotificationAPI.VoiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SugarNotificationAPI.Api
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("alexa")]
        public AlexaResponse AlexaSugarApp(AlexaRequest request)
        {
            AlexaResponse response = null;

            if (request != null)
            {
                switch (request.Request.Type)
                {
                    case "LaunchRequest":
                        response = RequestHandlers.LaunchRequestHandler(request);
                        break;
                    case "IntentRequest":
                        response = RequestHandlers.IntentRequestHandler(request);
                        break;
                    case "SessionEndedRequest":
                        response = RequestHandlers.SessionEndedRequestHandler(request);
                        break;
                }
            }

            return response;

        }
    }
}
