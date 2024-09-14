/*var mainAccounts = COAs.Where(x => x.Name == "Shared-COA" && x.MainAccountId.ToString().Length == 6)
    .Select(x =>
    {
        var mainAccountId = x.MainAccountId.ToString();
        var mainAccountPrefix = mainAccountId.Substring(0, 2); // Get first two digits

        // Parse the first two digits of MainAccountId to an integer
        int prefix = int.Parse(mainAccountPrefix);

        // Main Account Logic: Check if prefix is between 10 and 90 and the rest are "0000"
        if (prefix >= 10 && prefix <= 90 && mainAccountId.Substring(2) == "0000")
        {
            return new HeadSub
            {
                COAId = x.COAId,
                MainAccountId = x.MainAccountId,
                Name = x.Name,
                GLCode = x.MainAccountId,
                IsParent = true // It's a main account
            };
        }

        // Sub-Header Logic: Check if the main account has the next incremented prefix (e.g., 11 for 10, 21 for 20, etc.)
        else if (prefix >= 10 && prefix <= 90 && mainAccountId.Substring(2) == "0000" && mainAccountPrefix[1] == '1')
        {
            int expectedSubHeaderPrefix = prefix - 1; // Calculate the matching sub-header account (e.g., 11 for 10)

            // Ensure the sub-header account follows the correct pattern (e.g., 11 after 10)
            if (mainAccountPrefix == expectedSubHeaderPrefix.ToString())
            {
                return new HeadSub
                {
                    COAId = x.COAId,
                    MainAccountId = x.MainAccountId,
                    Name = x.Name,
                    GLCode = x.MainAccountId,
                    IsParent = false // It's a header sub-header account
                };
            }
        }

        return null; // Return null if no conditions are matched
    })
    .Where(x => x != null) // Filter out null entries
    .ToList();
*/
/*
var mainAccounts = COAs.Where(x => x.Name == "Shared-COA" && x.MainAccountId.ToString().Length == 6)
    .Select(x =>
    {
        var mainAccountId = x.MainAccountId.ToString();
        var mainAccountPrefix = mainAccountId.Substring(0, 2); // Get first two digits
        var subHeaderPrefix = mainAccountId.Substring(0, 3);   // Get first three digits for line items

        // Parse the first two digits of MainAccountId to an integer
        int prefix = int.Parse(mainAccountPrefix);

        // List of HeadSubs for each COA object
        List<HeadSub> headSubs = new List<HeadSub>();

        // List of LineItems for each HeadSub
        List<LineItem> lineItems = new List<LineItem>();

        // Main Account Logic: Check if prefix is between 10 and 90 and the rest are "0000"
        if (prefix >= 10 && prefix <= 90 && mainAccountId.Substring(2) == "0000")
        {
            headSubs.Add(new HeadSub
            {
                COAId = x.COAId,
                MainAccountId = x.MainAccountId,
                Name = x.Name,
                GLCode = x.MainAccountId,
                IsParent = true, // It's a main account
                LineItems = null // No line items for main accounts
            });
        }

        // Sub-Header Logic: Dynamically calculate sub-header (e.g., 11 for 10, 21 for 20, etc.)
        if (prefix >= 10 && prefix <= 90)
        {
            int expectedSubHeaderPrefix = prefix + 1; // Calculate sub-header (e.g., 11 for 10)

            var subHeaderAccount = $"{expectedSubHeaderPrefix}0000"; // Expected sub-header account

            if (mainAccountId == subHeaderAccount)
            {
                headSubs.Add(new HeadSub
                {
                    COAId = x.COAId,
                    MainAccountId = x.MainAccountId,
                    Name = x.Name,
                    GLCode = x.MainAccountId,
                    IsParent = false, // It's a sub-header
                    LineItems = null // Line items will be added dynamically
                });

                // Dynamically generate line item ID based on sub-header
                var lineItemAccount = $"{expectedSubHeaderPrefix}1000"; // Generate line item ID (e.g., 111000 for 110000)

                // Add the line item for the sub-header
                lineItems.Add(new LineItem
                {
                    COAId = int.Parse(x.COAId),
                    CreatedOn = DateTime.Now, // Example of setting current time, can be dynamic
                    CreatedBy = x.CreatedBy, // This field can be dynamically set
                    GlobalCOAData = new List<GlobalCOADataParameter>
                    {
                        new GlobalCOADataParameter
                        {
                            AccountCategory = "Example Category",
                            AccountHeader = "Example Header",
                            AccountSubHeader = "Example SubHeader",
                            GLCode = lineItemAccount // Line Item ID is dynamically generated
                        }
                    }
                });

                // Attach the generated line items to the sub-header
                headSubs.Last().LineItems = lineItems;
            }
        }

        // Return the COA with its associated HeadSubs and LineItems
        return new COAs
        {
            COAId = x.COAId,
            CountryId = x.CountryId,
            LegalEntityTypeId = x.LegalEntityTypeId,
            Name = x.Name,
            Region = x.Region,
            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,
            HeadSubs = headSubs // Attach the HeadSubs list to the COA
        };
    })
    .Where(x => x.HeadSubs != null && x.HeadSubs.Count > 0) // Filter out entries without HeadSubs
    .ToList();

https://chatgpt.com/share/66e50f19-18bc-8002-b321-dd1a3bd97cc8
*/