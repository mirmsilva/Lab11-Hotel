using Lab12.Data;
using Lab12.Models.DTOs;
using Lab12.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;


namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : TwilioController
    {
        private readonly HotelDbContext _context;
        private readonly IHotel _hotel;
        //private readonly object hotel;

        public SmsController(IHotel h, HotelDbContext c)
        {
            //set context to the private context created above
            _hotel = h;
            _context = c;
        }
        [HttpGet("api/sms/")]
        public ActionResult SendSms()
        {
            var hotel = new HotelSmsDto();

            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            //TODO IN FUTURE: ADD TOKENS/PHONE NUMBERS TO GITIGNORE

            //TOKENS
            string accountSid = "AC912cb5fe9add6927112bb9378db954a6";
            string authToken = "c44804d73bc069d52ba02e7bc168766c";

            //PHONE NUMBERS
            var miriam = new Twilio.Types.PhoneNumber("+12064033272");
            var twilio = new Twilio.Types.PhoneNumber("+12062223455");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hello, From the internet",
                from: twilio,
                to: miriam
            );
            return Content(message.Sid);
        }
   

        [HttpPost("api/response/")]
        public async Task<TwiMLResult> ReceiveSms()
        {
            

            var responseToUser = new MessagingResponse();

            //Request.Form["Body"] is where what the user text goes.
            //Set it to userInput
            var userInput = Request.Form["Body"].ToString();

            
            //Call the GetHotelbyNameMethod from HotelController
            //pass in userInput(Ideally a correctly spelled hotel name)
             HotelSmsDto hotel = await _hotel.GetHotelByName(userInput);
            

            //if the userInput matches the hotel Name in the database
            if (userInput == hotel.Name)
            {
                //return the corresponding address
                responseToUser.Message($"The name is {hotel.Name} and the address is {hotel.StreetAddress}");
            }

            return TwiML(responseToUser);
        }



        //STUFF FROM THE INTERNET THAT WORKS
        //[HttpPost("api/response/")]
        //public TwiMLResult ReceiveSms()
        //{
        //    var messagingResponse = new MessagingResponse();

        //    var requestBody = Request.Form["Body"].ToString();

        //    if (requestBody == "hello")
        //    {
        //        messagingResponse.Message("Hi!");
        //    }
        //    else if (requestBody == "bye")
        //    {
        //        messagingResponse.Message("Goodbye");
        //    }

        //    return TwiML(messagingResponse);
        //}

        //get user text and use to do a query
    }
}
