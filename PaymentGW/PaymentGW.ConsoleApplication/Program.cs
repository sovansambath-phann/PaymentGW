using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;
using PaymentGW.Application.BounceContext.Card.DTO;
using PaymentGW.Application.BounceContext.Validation.DTO;

namespace PaymentGW.ConsoleApplication {
    class Program {
        static readonly string URL_FORMART = "http://localhost:8861/api/card/checkcard/{0}/{1}";
        static readonly int TOTAL_CARD_NUMBER = 100;

        static void Main(string[] args) {
            System.Console.WriteLine("- Start");

            log4net.Config.XmlConfigurator.Configure();
            ILog logger = log4net.LogManager.GetLogger("Error");

            var allValidationResults = new List<ValidationResult>();
            try {

                var allCards = new List<CardDto>();
                Console.WriteLine(string.Format("- get {0} random cards", TOTAL_CARD_NUMBER));
                CardDto[] randomCards = CreateRandomCardNumber(TOTAL_CARD_NUMBER);
                foreach (var eachCard in randomCards) {
                    Console.WriteLine(string.Format("- cardNumber : {0} , expiryYear : {1}", eachCard.CardNumber, eachCard.ExpiryYear));
                    allCards.Add(eachCard);
                }

                Console.WriteLine(string.Format("- get existing card in db to test it . there are 20 cards in db"));
                CardDto[] cardInDb = CreateCardFromDB();
                foreach (var eachCard in cardInDb) {
                    Console.WriteLine(string.Format("- cardNumber : {0} , expiryYear : {1}", eachCard.CardNumber, eachCard.ExpiryYear));
                    allCards.Add(eachCard);

                }

                // using parallel request 
                var obj = new object();
                var random = new Random();
                Parallel.ForEach(allCards, (eachCard) => {
                    try {
                        var eachUrl = string.Format(URL_FORMART,eachCard.CardNumber,eachCard.ExpiryYear);
                        Console.WriteLine(string.Format("- start request url : {0}, ThreadId:{1}", eachUrl, System.Threading.Thread.CurrentThread.ManagedThreadId));

                        var eachResult = new RequestHelper().MakeRquest(eachUrl);
                        lock (obj) {
                            allValidationResults.Add(eachResult);
                            System.Console.WriteLine(string.Format("- end request , ThreadId:{0}", System.Threading.Thread.CurrentThread.ManagedThreadId));
                        }
                    }catch (AggregateException aEx) {
                        System.Console.WriteLine(aEx.Message);
                        System.Console.WriteLine("- ThreadId :{0} is failed to do request", System.Threading.Thread.CurrentThread.ManagedThreadId);
                    }
                });

            }catch (Exception ex) {
                logger.Error(ex);
                Console.WriteLine(ex.Message);
            }

            // dispaly all result
            Console.WriteLine("\n- Display results");
            foreach (var eachResult in allValidationResults){
                Console.WriteLine(string.Format("- cardNumber:{0} , cardType : {1} , isValid :{2} , message : {3}",eachResult.CardNumber,eachResult.CardType.ToString(),eachResult.IsValid.ToString(),eachResult.Message));
                
            }

            Console.WriteLine("- End");
            System.Threading.Thread.Sleep(5 * 1000);
        }

        static CardDto[] CreateRandomCardNumber(int totalCardNumber) {
            Console.WriteLine(string.Format("- start to generate {0} cards.....",totalCardNumber));
            List<CardDto> cards = new List<CardDto>();

            var random = new Random();
            var cardNumber = string.Empty;
            var expiryYear = string.Empty;
            for (int i = 0; i < totalCardNumber; i++) {
                if(i%2==0){
                    cardNumber = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}", 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9), 
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9));
                }else{
                    cardNumber = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}",
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9),
                                    random.Next(0, 9));
                }

                expiryYear = string.Format("{0}{1}", DateTime.Now.ToString("MM"), random.Next(2018, 2050));

                cards.Add(new CardDto(cardNumber,expiryYear));
                System.Threading.Thread.Sleep(50 + i);
            }

            // add existing card in database 
            

            return cards.ToArray();
        }

        static CardDto[] CreateCardFromDB() {
            //we have add 20 cards in db
            return new CardDto[]{
                new CardDto("4111111111111111","012020"),
                new CardDto("4111111111111112","012020"),
                new CardDto("4111111111111113","012020"),
                new CardDto("4111111111111114","012020"),
                new CardDto("4111111111111115","012020"),
                new CardDto("5111111111111111","012017"),
                new CardDto("5111111111111112","012017"),
                new CardDto("5111111111111113","012017"),
                new CardDto("5111111111111114","012017"),
                new CardDto("5111111111111115","012017"),
                new CardDto("311111111111111","062019"),
                new CardDto("311111111111112","062019"),
                new CardDto("311111111111113","062019"),
                new CardDto("311111111111114","062019"),
                new CardDto("311111111111115","062019"),
                new CardDto("3111111111111111","062019"),
                new CardDto("3111111111111112","062019"),
                new CardDto("3111111111111113","062019"),
                new CardDto("3111111111111114","062019"),
                new CardDto("3111111111111115","062019"),
            };
        }
    }
}
