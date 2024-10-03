/*
 
Inlämningsuppgift 1: Skapa en adressbok


Beskrivning
Uppgiften handlar om att skapa en adressbok.
All information skall sparas i en textfil.
Det betyder att applikationen skall kunna läsa och skriva från denna textfil.
Gränssnittet till applikationen skall skapas i Windows Forms.

Krav för att uppgiften skall bli godkänd:
- Följande information skall kunna registreras och sparas till textfilen, namn, gatudress,
postnummer, postort, telefon och epost
- Det skall gå att spara en ny adress i adressboken men också uppdatera en adress som
redan finns.
- Det skall gå att ta bort en adress och den skall då försvinna från adressboken.
- Det skall gå att söka på en eller flera adresser och sökresultatet skall visas i en lista.
- Från listan skall det gå att klicka på en rad och få upp all information om den adressen.
- Sökningen skall fungera som ett urval där det minst skall gå att göra urval på namn
och postort.
Koden skall fungera och applikationen skall gå att köra utan fel. 
 
 */


namespace ContactsV1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                try
                {
                    showMenu = MainMenu();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Välje ett tal mellan 1 och 4!/n Eller andra sorts fel vid inmatning av data" + e);
                    Console.ReadKey();
                }

            }


        }

        //Klassen "Contact" med egenskaperna namn, gatudress,
        //postnummer, postort, telefon och epost deklareras nedan
        class Contact
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string ZipCode { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }

            //Metoderna som har med Contacts att göra deklareras (skissas) i samma kodblok som själva klasen

            //Konsttruktorn
            public Contact(string name, string address, string city, string zipCode, string phoneNumber, string email)
            {
                Name = name;
                Address = address;
                City = city;
                ZipCode = zipCode;
                PhoneNumber = phoneNumber;
                Email = email;
            }

        }


        //Filhantering 0: Att hämta kontakter till en lista med datatyp Contact
        private static List<Contact> LoadContacts()
        {
            List<Contact> contactsList = new List<Contact>();
            string file = @"C:\Users\PARLUOL03\source\repos\ContactsV1\addressBook.txt";
            using (StreamReader reader = new StreamReader(file))
            {
                string row;
                //Så länge det finns rader i filen loopa igenom och läs ut raden
                while ((row = reader.ReadLine()) != null)
                {
                    string[] contactsDetails = row.Split(",");
                    Contact contact = new Contact(contactsDetails[0], contactsDetails[1], contactsDetails[2], contactsDetails[3], contactsDetails[4], contactsDetails[5]);
                    contactsList.Add(contact);
                }
                contactsList.Sort();
            }
            return contactsList;
        }
        
       
        //Filhantering 1: Att spara en kontakt i en fil
        private static void SaveContactInFile(Contact contact)
        {
            string file = @"C:\Users\PARLUOL03\source\repos\ContactsV1\addressBook.txt";

            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(
                    contact.Name + "," +
                    contact.Address + "," +
                    contact.City + "," +
                    contact.ZipCode + "," +
                    contact.PhoneNumber + "," +
                    contact.Email);

            }
        }



        //Filhantering 2: Att redigera en kontakt som redan finns i filen

        //Filhantering 3: Att ta bort en kontakt från filen

        //Filläsning: Det skall gå att söka på en eller flera adresser och sökresultatet skall visas i en lista.

        //Filläsning: Från listan skall det gå att klicka på en rad och få upp all information om den adressen.

        //Filläsnning: Sökningen skall fungera som ett urval där det minst skall gå att göra urval på namn
        //och postort. (att göra för Windows Form)






        //Metoderna som har med Console menyn att göra deklareras (skissas) nedan
        private static bool MainMenu()
        {

            //Presentera menyn
                Console.Clear();
                Console.WriteLine(
                    "Välj ett nummer: \n" +
                    "1. Sök | 2. Skapa | 3. Redigera | 4. Exit"
                    );
                //Variabeln till swich:en matas in av användaren
                int nr = int.Parse(Console.ReadLine());
                switch (nr)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("1. Sök.");
                        SearchContact();
                        return true;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("2. Skapa kontakt.");
                        SaveContactInFile(CreateContact());
                        return true;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("3. Redigera kontakt.");
                        return true;
                    case 4:
                        return false;
                    default:
                        Console.WriteLine("Välje ett tal mellan 1 och 4!");
                        return true;
                   

                }

        }

        //Metoden som söker en kontakt med hjälp av Consolen
        private static void SearchContact()
        {
            string file = @"C:\Users\PARLUOL03\source\repos\ContactsV1\addressBook.txt";
            
            Console.WriteLine("Skriv sökord:");
            string searchCondition = Console.ReadLine();

            using (StreamReader reader = new StreamReader(file))
            {

                string row;

                //Vi loppar igenom alla rader i filne. När vi kommer till sita raden
                //blir row lika med null. Då bryts loopen

                while ((row = reader.ReadLine()) != null)
                {
                    if (row.ToLower().Contains(searchCondition.ToLower()))
                    {
                        Console.WriteLine(row);

                    }

                }
                Console.WriteLine("Tryck på vilken knapp som helst för att återkomma till menyn.");
                Console.ReadKey();
            }


        }

        //Metoden skappar en kontakt med hjälp av Consolen
        private static Contact CreateContact()
        {
            Console.WriteLine("Skriv kontaktens namn:");
            string name = Console.ReadLine();
            Console.WriteLine("Skriv kontaktens gatuadress:");
            string address = Console.ReadLine();
            Console.WriteLine("Skriv kontaktens postort:");
            string city = Console.ReadLine();
            Console.WriteLine("Skriv kontaktens postnummer:");
            string zipCode = Console.ReadLine();
            Console.WriteLine("Skriv kontaktens telefonnummer:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Skriv kontaktens emajladress:");
            string email = Console.ReadLine();
            Contact contact = new Contact(name, address, city, zipCode, phoneNumber, email);
            return contact;

        }
    }
}
