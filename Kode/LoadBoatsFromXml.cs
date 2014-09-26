public static void UpdateBoatsFromFtp(bool saveChanges = true) 
{
    var context = DbArkContext.GetDbContext();

    var xmlString = DownloadLatestFromFtp(@"BådeSpecifik.xml");
    if (xmlString == null) 
    {
        // If xmlString is null, no update is needed and the function returns immediately
        return;
    }
    var xmlObject = ParseXML<XMLBoats.dataroot>(xmlString);

    foreach (var boat in context.Boat) 
    {
        if (xmlObject.BådeSpecifik.All(x => x.ID != boat.Id)) 
        {
            context.Boat.Remove(boat);
        }
    }

    foreach (var boatXml in xmlObject.BådeSpecifik) 
    {
        Boat boat;
        if ((boat = context.Boat.Find(boatXml.ID)) != null) 
        {
            BoatXmlToModel(boat, boatXml);
        } 
        else 
        {
            boat = new Boat() 
            {
                DamageForms = new List<DamageForm>(),
                LongTripForms = new LinkedList<LongTripForm>()
            };
            BoatXmlToModel(boat, boatXml);
            context.Boat.Add(boat);
        }
    }

    if (saveChanges) 
    {
        context.SaveChanges();
    }
}