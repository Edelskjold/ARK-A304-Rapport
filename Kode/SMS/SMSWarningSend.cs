        private void HandleWarningSms(IEnumerable<TripWarningSms> warnings)
        {
            var pending = warnings.Where(warning => warning.SentSms == null);

            foreach (var sms in pending)
            {
                foreach (var member in sms.Trip.Members.Where(member => !string.IsNullOrEmpty(member.Phone)))
                {
                    this.Gateway.SendSms(
                        Sender, 
                        member.Phone, 
                        string.Format(MessageNotHome, member.FirstName + " " + member.LastName));
                }

                sms.SentSms = DateTime.Now;
            }
        }