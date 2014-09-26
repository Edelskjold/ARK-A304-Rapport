public class SmsWarnings
    {
        private const string Sender = "ARK";
        private const string MessageNotHome =
            "Hej {0} Bekræft venligst med OK, at du har det godt. Venlig hilsen Aalborg Roklub";
        private const string MessageInvalidResponse = "Bekræftelsen blev ikke modtaget";
        private const string MessageValidResponse = "Bekræftelsen blev succesfuldt modtaget";
        private const string MessageNotHomeAdministration = "Nogle af medlemmerne på rotur er ikke kommet hjem endnu";

        public SmsWarnings()
        {
            Gateway = new DemoSMSGateway();
        }

        public ISmsGateway Gateway { get; set; }

        public void Test()
        {
            // Gør kun dette her når solen er nede

            if (IsAfterSunset() || true)
            {

                using (var db = new DbArkContext())
                {
                    var warnings = GetTripWarningSms(db).ToList();
                    var responses = db.GetSMS.ToList();

                    HandleWarningSms(warnings);
                    HandleResponseSms(warnings, responses);

                    // Fjern tidligere sms'er
                    db.GetSMS.RemoveRange(responses);

                    db.SaveChanges();
                }
            }
        }