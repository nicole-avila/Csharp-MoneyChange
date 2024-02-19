//Vi lägger in en whiel loop för att hålla igång applikationen
bool runngingProgram = true;

while(runngingProgram)
{
    //Här ska användaren skriva in det totala priset för varorna.
    Console.Write("Ange varornas pris: ");

    //skapa en variabel price för att använda den i en  TrypParse if-sats
    decimal price;

    //Vi förösker Parsa input från avändaren, ifall vi lyckas så tilldelar (använder oss utav OUT) vi värdet av Pars:ningen till vår variabel PRICE.
    //med andra ord - Om den inte kan Parsa, ta emot en siffra i decimal
    if (!decimal.TryParse(Console.ReadLine(), out price))
    {
        Console.WriteLine("Ogiltigt pris. Försök igen!");
    }


    //Och sedan skriva in det betalda beloppet
    Console.Write("Ange beloppet kunden har betalat: ");

    //skapa en variabel totalPayment för att använda den i en  TrypParse if-sats
    decimal totalPayment;

    //Här använder vi oss utav en TryParse ifall användaren skriva något annat än en siffra. Vi skriver ut ett felmedelande om användaren skriver ett ord ist för ett nummer.
    if (!decimal.TryParse(Console.ReadLine(), out totalPayment))
    {
        Console.WriteLine("Ogiltigt pris. Försök igen!");
    }

    //Här räknar vi ut växeln. Vi tar betalningen minus priset på varorna och skriver ut svaret till användaren
    decimal change = totalPayment - price;

    //Här vill jag lägg in en felhantering till användaren IFALL kunden ger för lite pengar.
    //om change (växeln tillbaka) är mindre än noll så skriv ut ett meddelande till användaren. 
    if(change < 0 )
    {
    Console.WriteLine("Det saknas mer pengar");
    }
    else
    {
        Console.WriteLine($"växel att få tillbaka: {change}kr");
    }

    // Här använder vi inbyggda avrundning operation för att ta hand om avrundnings logiken.
    // gånger 2 för att vi vill få så bra nära till avrundningen. och sedan delat med 2 för att få rätt avrundning. 
    change = Math.Round(change * 2, MidpointRounding.AwayFromZero) / 2;

    //Här anropar vi den lokala funktionen som beräknar och utför en modolo operator för sedlar och mynt.
    CalculateAndPrinthange(change);

    //Här gör vi en break-line
    Console.WriteLine("\n");
    //Här skriver vi ut ett medelande till användaren om hen vill fortsätta med applikationen
    Console.WriteLine("Vill du avsluta applikationen? ja/nej");

    //Läser in en sträng från användaren, userInput och omvandlar den till små bokstäver.
    string userInput = Console.ReadLine()!.ToLower();

    //Om användarens input är lika med "ja" så avbryt applikationen
    if (userInput == "ja")
    {
        runngingProgram = false;
    }
    //Om "nej" låt applikationen fortsätta
    else if (userInput == "nej")
    {
        runngingProgram = true;
    }
    //Om användare skriver varken ja eller nej så skriv ut ett medelande till användaren, med förtydlingande 
    else
    {
        Console.WriteLine("jag förstår inte! Ge mig ett nytt svar, med ja eller nej");
    }

}

//Här skapar vi local method/function för att sedan anropa funktionen inne i while-loppen.
//Denna funktionen ska egentligen retunera int som datatyp.. Ändra det och se vad som behövs ändras i variebeln som finns med i parametern. 
static decimal CalculateAndPrinthange(decimal changeInt)
{
    //Här nedan räknar vi ut hur många sedlar och mynt köparen ska få tillbaka.
    //Omvandlar decimal variabeln, change till en ny variabel med int-datatyp och dela med 1000/500/100 osv med resterande sedlar och mynt.
    //Under samtliga int-varabel användar vi Modulo Operator, % för att räkna ut det resterande belopp från växeln. Och räknar ner till varje sedlen och ner till mynt.
    int thousand = (int) changeInt / 1000;
    changeInt %= 1000;

    int fivehoundred = (int) changeInt / 500;
    changeInt %= 500;

    int houndred = (int) changeInt / 100;
    changeInt %= 100;

    int fifty = (int) changeInt / 50;
    changeInt %= 50;

    int twenty = (int) changeInt / 20;
    changeInt %= 20;

    int ten = (int) changeInt / 10;
    changeInt %= 10;

    int five = (int) changeInt / 5;
    changeInt %= 5;

    int one = (int) changeInt / 1;
    changeInt %= 1;

    int cent = (int) (changeInt / 0.5m);


    //Skriv ut till användaren vad köparen ska få tillbaka i antal sedlar och mynt.
    Console.WriteLine($"Antal 1000-sedlar: {thousand}st");
    Console.WriteLine($"Antal 500-sedlar: {fivehoundred}st");
    Console.WriteLine($"Antal 100-sedlar: {houndred}st");
    Console.WriteLine($"Antal 50-sedlar: {fifty}st");
    Console.WriteLine($"Antal 20-sedlar: {twenty}st");
    Console.WriteLine($"Antal 10-kronor: {ten}st");
    Console.WriteLine($"Antal 5-kronor: {five}st");
    Console.WriteLine($"Antal 1-kronor: {one}st");
    Console.WriteLine($"Antal 50-öre: {cent}st");

    //I den här funktionen retunerar vi changeInt för att anropa det i whilip-loopen ovan. 
    return changeInt;
}