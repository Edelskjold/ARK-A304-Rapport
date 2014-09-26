Phone = new Func<string, string>(x => x != null ? 
    Regex.Replace(x, @"[^0-9]", string.Empty) : 
    string.Empty).Invoke((string)memberXml.
    GetObjFromName(XMLMembers.ItemsChoiceType.Telefon))