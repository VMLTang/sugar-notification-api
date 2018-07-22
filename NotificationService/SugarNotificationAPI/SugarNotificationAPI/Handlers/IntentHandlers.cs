using SugarNotificationAPI.VoiceModels;
using System;

namespace SugarNotificationAPI.Handlers
{
    public class IntentHandlers
    {
        public static AlexaResponse HelloIntentHandler(AlexaRequest request)
        {
            //Alexa, tell Sugar App to say hi
            //ALEXA: Hey there, neighbor!
            //ALEXA Reprompt: Say Help if you need a list of options.

            try
            {
                var response = new AlexaResponse();
                response.Response.Card.Title = "Hello!";
                response.Response.Card.Content = "Hello from Sugar!";
                response.Response.OutputSpeech.Type = "SSML";
                response.Response.OutputSpeech.Ssml = "<speak> Hey there, neighbor! </speak>";
                response.Response.Reprompt.OutputSpeech.Text = "Say Help if you need a list of options.";
                response.Response.ShouldEndSession = false;
                response.Session.LastIntentName = "HelloIntent";

                return response;
            }
            catch (Exception ex)
            {
                var response = new AlexaResponse("Ouch! I'm broken... it happens." + ex.Message);
                return response;
            }
        }

        public static AlexaResponse CreateOfferIntentHandler(AlexaRequest request)
        {
            //Tell Sugar App I have {Quantity} of {FoodItem} to offer
            //ALEXA: Got it. Anything else?
            //ALEXA Reprompt: Say help to hear a list of options

            var response = new AlexaResponse();

            var quantity = request.Request.Intent.Slots["Quantity"].value;
            if (quantity != null)
                quantity = request.Request.Intent.Slots["Quantity"].value.ToString();

            var foodItem = request.Request.Intent.Slots["FoodItem"].value;

            if (foodItem != null)
                foodItem = request.Request.Intent.Slots["FoodItem"].value.ToString();
            else
            {
                response.Response.OutputSpeech.Text = "Sure. What kind of food item are you offering?";
                response.Response.Card.Title = "Food item not provided";
                response.Response.Card.Content = "Please provide the kind of food you wish to offer.";
                response.Response.Reprompt.OutputSpeech.Text = "Which food item are you wanting to offer?";
                response.Response.ShouldEndSession = false;

                return response;
            }

            //TODO: Call Data API and create offer posting

            response.Response.OutputSpeech.Text = "Got it. Anything else?";
            response.Response.Card.Title = "Create Offer";
            response.Response.Card.Content = "An offer for " + foodItem + " will be created.";
            response.Response.Reprompt.OutputSpeech.Text = "Say Help to hear a list of options or cancel to exit.";
            response.Response.ShouldEndSession = false;
            response.Session.LastIntentName = "CreateOfferIntent";

            return response;
        }

        public static AlexaResponse AdditionalOfferIntentHandler(AlexaRequest request)
        {
            //Yes
            //ALEXA: What's next?

            var response = new AlexaResponse();

            response.Response.OutputSpeech.Text = "What's next?";
            response.Response.Card.Title = "Food item not provided";
            response.Response.Card.Content = "Please provide the kind of food you wish to offer.";
            response.Response.Reprompt.OutputSpeech.Text = "Which food item are you wanting to offer?";
            response.Response.ShouldEndSession = false;

            return response;
        }

        public static AlexaResponse ConfirmOfferCreationIntentHandler(AlexaRequest request)
        {
            //No
            //ALEXA: Thanks for offering to share. Your listing has been created.

            var response = new AlexaResponse(
                "Thanks for offering to share. Your listing has been created. We'll let you know by text when someone is interested.");
            response.Response.Card.Title = "Offers Created";
            response.Response.Card.Content = "All offers have been created on your behalf";
            response.Response.ShouldEndSession = true;
            response.Session.LastIntentName = "ConfirmOfferCreationIntent";
            return response;
        }

        public static AlexaResponse NearbyRequestsIntentHandler(AlexaRequest request)
        {
            //Ask Sugar App if there are any food requests near me
            //ALEXA: Yes, there are 3 requests near you at the moment. I'll send you the link in your Alexa app.

            var response = new AlexaResponse(
                "Yes, there are 3 requests near you at the moment. I'll send you the website link so you can take a look.");
            response.Response.Card.Title = "Requests Nearby";
            response.Response.Card.Content = "There are 3 people requesting food items nearby.";
            response.Response.ShouldEndSession = true;
            response.Session.LastIntentName = "NearbyRequestsIntent";
            return response;
        }

        public static AlexaResponse HelpIntentHandler()
        {
            //Help
            //ALEXA: Say hello or cancel to exit.
            //ALEXA Reprompt: Say hello or cancel to exit.

            var response = new AlexaResponse("Say hello, I have a food item to offer, are there any food requests near me, or cancel to exit.");
            response.Response.Card.Title = "Options";
            response.Response.Card.Content = "Say hello, I have a food item to offer, are there any food requests near me, or cancel to exit\n";
            response.Response.Reprompt.OutputSpeech.Text = "Say hello or cancel to exit.";
            response.Response.ShouldEndSession = false;
            return response;
        }

        public static AlexaResponse CancelOrStopIntentHandler()
        {
            //Cancel/Quit/Bye
            //ALEXA: Goodbye.

            var response = new AlexaResponse("Check back anytime.");
            response.Response.Card.Title = "Farewell";
            response.Response.Card.Content = "May the Force be with you.";
            response.Response.ShouldEndSession = true;
            return response;
        }

        public static AlexaResponse DefaultIntentHandler(AlexaRequest request)
        {
            var response = new AlexaResponse("I didn't understand what you requested. Say help to hear a list of options or cancel to exit.");
            response.Response.Reprompt.OutputSpeech.Text = "Say help to hear a list of options or cancel to exit.";
            response.Response.ShouldEndSession = false;
            return response;
        }
    }
}