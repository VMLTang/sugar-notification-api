using SugarNotificationAPI.VoiceModels;

namespace SugarNotificationAPI.Handlers
{
    public class RequestHandlers
    {
        public static AlexaResponse LaunchRequestHandler(AlexaRequest request)
        {
            //Alexa, start {name of skill}
            //ALEXA: Welcome
            //ALEXA Reprompt: Please say Help if you need a list of commands

            var response = new AlexaResponse("Welcome to Sugar, where we feed it forward to those nearby.");
            response.Response.Card.Title = "Welcome to Sugar";
            response.Response.Card.Content = "Please say Help if you need a list of options";
            response.Response.Reprompt.OutputSpeech.Text = "Please say Help if you need a list of options.";
            response.Response.ShouldEndSession = false;

            return response;
        }

        public static AlexaResponse IntentRequestHandler(AlexaRequest request)
        {
            AlexaResponse response = null;

            switch (request.Request.Intent.Name)
            {
                case "HelloIntent":
                    response = IntentHandlers.HelloIntentHandler(request);
                    break;
                case "CreateOfferIntent":
                    response = IntentHandlers.CreateOfferIntentHandler(request);
                    break;
                case "AMAZON.YesIntent":
                    response = IntentHandlers.AdditionalOfferIntentHandler(request);
                    break;
                case "AMAZON.NoIntent":
                    response = IntentHandlers.ConfirmOfferCreationIntentHandler(request);
                    break;
                case "NearbyRequestsIntent":
                    response = IntentHandlers.NearbyRequestsIntentHandler(request);
                    break;
                case "AMAZON.CancelIntent":
                case "AMAZON.StopIntent":
                    response = IntentHandlers.CancelOrStopIntentHandler();
                    break;
                case "AMAZON.HelpIntent":
                    response = IntentHandlers.HelpIntentHandler();
                    break;
                default:
                    response = IntentHandlers.DefaultIntentHandler(request);
                    break;
            }

            return response;
        }

        public static AlexaResponse SessionEndedRequestHandler(AlexaRequest request)
        {
            return null;
        }
    }
}