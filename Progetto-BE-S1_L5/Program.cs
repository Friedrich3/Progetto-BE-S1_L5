using System.Text.RegularExpressions;
using Progetto_BE_S1_L5.Models;

Console.WriteLine("Benvenuto nell'applicazione, digita quale operazione vuoi compiere");
Console.WriteLine("1. Calcola Imposta");
Console.WriteLine("2. Esci");
menu:
Console.Write("Operazione: ");
string operazione = Console.ReadLine()!;
switch (operazione)
{
    case "1":
Console.WriteLine("--Inserisci i tuoi dati--");
Nome:
Console.Write("Inserisci il tuo nome: ");
var nome = Console.ReadLine()?.ToUpper();
nome = Regex.Replace(nome.Trim(), @"\s+", " ");
if (!Contribuente.CheckNome(nome))
{
    goto Nome;
}

Cognome:
Console.Write("Inserisci il tuo cognome: ");
var cognome = Console.ReadLine()?.ToUpper();
cognome = Regex.Replace(cognome.Trim(), @"\s+", "");
if (!Contribuente.CheckCognome(cognome))
{
goto Cognome;
}
else
{
}

DataNascita:
Console.Write("Inserisci la tua data di nascita (gg/mm/aaaa): ");
var dataNascita = Console.ReadLine();
if (!Contribuente.CheckData(dataNascita))
{
    goto DataNascita;
}


Sesso:
Console.Write("Inserisci il tuo sesso (m/f): ");
var sesso = Console.ReadLine()?.ToUpper();
sesso = Contribuente.CheckGender(sesso);



Comune:
Console.Write("Inserisci il tuo comune di residenza: ");
var comune = Console.ReadLine()?.ToUpper();
comune = Regex.Replace(comune.Trim(), @"\s+", " ");
if (!Contribuente.CheckComune(comune))
{
goto Comune;
}
else
{
}

codiceFiscale:
Console.Write("Inserisci il tuo codice fiscale: ");
var codiceFiscale = Console.ReadLine()?.ToUpper();
if (!Contribuente.CheckCF(codiceFiscale))
{
    goto codiceFiscale;
}


Ral:
Console.Write("Inserisci il Reddito: ");
decimal ral;
var reddito = Console.ReadLine();
if (!Contribuente.CheckRal(reddito))
{
    goto Ral;
}
else
{
    ral = decimal.Parse(reddito);
}


Contribuente newContribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comune, ral);

newContribuente.CalcoloImposta();
goto menu;


    case "2":
        Environment.Exit(0);
        break;


    default:
        goto menu;
}