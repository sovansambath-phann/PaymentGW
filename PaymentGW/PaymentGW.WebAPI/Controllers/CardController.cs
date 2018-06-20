using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaymentGW.Domain.BounceContext;
using System.Data;
using System.Data.Entity.Core.Objects;
using log4net;
using PaymentGW.WebAPI.Models;
using PaymentGW.Application.BounceContext.Validation.DTO;
using PaymentGW.Application.BounceContext.Validation.Service;
using PaymentGW.Application.BounceContext.Card.DTO;
using PaymentGW.Application.BounceContext.Card.Exceptions;
using PaymentGW.Application.BounceContext.Card.Service;

namespace PaymentGW.WebAPI.Controllers {
    [RoutePrefix("api")]
    public class CardController : ApiController {
        ILog logger = log4net.LogManager.GetLogger("Error");

        [HttpGet]
        [Route("card/checkcard/{cardNumber}/{expiryYear}")]
        public HttpResponseMessage Get(string cardNumber, string expiryYear) {
            HttpResponseMessage response = null;
            try {
                IValidationService validationService = new ValidationService();
                var validationResult = validationService.Validate(cardNumber,expiryYear);
                if (!validationResult.IsValid) {
                    response = new HttpResponseMessage() { 
                        Content = new JsonContent(validationResult)
                    };
                }else {
                    ICardService cardService = new CardService();
                    int year = cardService.GetCardExpiryYear(expiryYear);

                    ACard card = CardFactory.GetCard(cardNumber, year);
                    var isValidCardNumber = card.IsValid();
                    response = new HttpResponseMessage() {
                        Content = new JsonContent(new PaymentGW.Application.BounceContext.Validation.DTO.ValidationResult() {
                            CardNumber = cardNumber,
                            IsValid = isValidCardNumber,
                            Message = string.Empty,
                            CardType = card.GetCardType()
                        })
                    };
                }
            }catch (UnknownCardException uEx) {
                logger.Error(uEx);
                response = new HttpResponseMessage() {
                    Content = new JsonContent(new PaymentGW.Application.BounceContext.Validation.DTO.ValidationResult() {
                        CardNumber = cardNumber,
                        IsValid = false,
                        Message = "Card is unknonw"
                    })
                };
            }catch (Exception ex) {
                logger.Error(ex);
                
                response = new HttpResponseMessage() {
                    Content = new JsonContent(new PaymentGW.Application.BounceContext.Validation.DTO.ValidationResult() {
                        CardNumber = cardNumber,
                        IsValid = false,
                        Message = "There are errors happens .Please contact the PaymentGW ."
                    })
                };

            }

            return response;
        }
    }
}