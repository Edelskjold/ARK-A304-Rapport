private void HandleResponseSms(IEnumerable<TripWarningSms> warnings, IEnumerable<GetSMS> responses)
{
    foreach (var response in responses)
    {
        var warn =
            warnings
                .Where(warning => warning.Trip.Members
                    .Any(member => member.Phone == response.From.Replace("+45", "")))
                .ToList();

        if (warn.Any())
        {
            if (response.Text.ToLower() == "ok")
            {
                warn[0].RecievedSms = response.RecievedDate;
                Gateway.SendSms(Sender, response.From.Replace("+45", ""), MessageValidResponse);
            }
            else
            {
                Gateway.SendSms(Sender, response.From.Replace("+45", ""), MessageInvalidResponse);
            }
        }
    }
}