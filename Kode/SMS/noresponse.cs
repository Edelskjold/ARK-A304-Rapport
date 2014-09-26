		private void HandleNoResponseSms(IEnumerable<TripWarningSms> warnings, DbArkContext db)
        {
            foreach (
                var warn in
                    warnings.Where(warn => !warn.RecievedSms.HasValue)
                        .Where(warn => warn.SentSms.HasValue && !warn.SentAdminSms.HasValue)
                        .AsEnumerable()
                        .Where(warn => (DateTime.Now - warn.SentSms.Value).TotalMinutes > 15))
            {
                var numbers = db.Admin.Where(a => a.ContactDark && a.Member.Phone != null).Select(a => a.Member.Phone);

                foreach (var number in numbers)
                {
                    this.Gateway.SendSms(Sender, number, MessageNotHomeAdministration);
                }

                warn.SentAdminSms = DateTime.Now;
            }
        }