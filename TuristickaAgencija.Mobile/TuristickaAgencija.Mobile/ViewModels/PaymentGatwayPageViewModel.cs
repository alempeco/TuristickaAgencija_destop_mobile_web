using Acr.UserDialogs;
using TuristickaAgencija.Model;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class PaymentGatewayViewModel : BindableBase
    {
        #region Variable

        private CreditCardModel _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;

        #endregion Variable

        #region Public Property
        private string StripeTestApiKey = "pk_test_51IKkEqKF7t0INLe8TvpXNkZTH7raFpp0X5uc69A8GmG60ambocaR1HMu1HyTCobzebB0KEYqVrObzgPUU8iZ0IWt00JnMz2MQF";
        private string StripeSecretApiKey = "sk_test_51IKkEqKF7t0INLe8RIezoQBOa5FCIR98NJ49xR4iVkLGNNoSxHcJVxxHZfLAiqGybJycj9N4UMAW8JntObXfmqIe00vigQvI5m";
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }

        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }

        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }
        float _amount = 0;
        public float Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }

        public CreditCardModel CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }

        #endregion Public Property

        #region Constructor

        public PaymentGatewayViewModel()
        {
            CreditCardModel = new CreditCardModel();
            Title = "Card Details";
        }

        #endregion Constructor

        #region Command

        public DelegateCommand SubmitCommand => new DelegateCommand(async () =>
        {
            CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth);
            CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                UserDialogs.Instance.ShowLoading("Payment processing..");
                await Task.Run(async () =>
                {

                    var Token = CreateToken();
                    Console.Write("Payment Gateway" + "Token :" + Token);
                    if (Token != null)
                    {
                        IsTransectionSuccess = MakePayment(Token);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Bad card credentials", null, "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                Console.Write("Payment Gatway" + ex.Message);

            }

            if (IsTransectionSuccess)
            {
                Console.Write("Payment Gateway" + "Payment Successful ");
                UserDialogs.Instance.Alert("Your payment was successfull", "Payment success", "OK");
                UserDialogs.Instance.HideLoading();

            }
            else
            {

                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Oops, something went wrong", "Payment failed", "OK");
                Console.Write("Payment Gateway" + "Payment Failure ");
            }


        });

        #endregion Command

        #region Method

        private string CreateToken()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeTestApiKey;
                var service = new ChargeService();
                var Tokenoptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = APIService.KorisnickoIme,
                        AddressLine1 = "Adresa 1",
                        AddressLine2 = "Adresa 2",
                        AddressCity = "Mostar",
                        AddressZip = "88000",
                        AddressState = "HNK",
                        AddressCountry = "Bosnia and Herzegovina",
                        Currency = "bam",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool MakePayment(string token)
        {
            try
            {
                StripeConfiguration.ApiKey = StripeSecretApiKey;
                var options = new ChargeCreateOptions
                {
                    Amount = ((long)Amount) * 100,
                    Currency = "bam",
                    Description = APIService.KorisnickoIme,
                    Source = stripeToken.Id,
                    StatementDescriptor = "Custom descriptor",
                    Capture = true,
                    ReceiptEmail = "random.person@gmail.com",
                };
                //Make Payment
                var service = new ChargeService();
                Charge charge = service.Create(options);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway (CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        private bool ValidateCard()
        {
            if (CreditCardModel.Number.Length == 16 && ExpMonth.Length == 2 && ExpYear.Length == 2 && CreditCardModel.Cvc.Length == 3)
            {
                return true;
            }
            return false;
        }

        #endregion Method
    }
}