# King Akademija 2022
Dobrodošli na ljetnu King akademiju! Drago nam je da ste dio ove priče i nadamo se da ćemo se lijepo zabaviti, a uz to nešto i naučiti. U nastavku će biti objašnjeni slojevi arhitekture korištene u zadatku.

## KingICT.Academy.WebApi
U ovom sloju nalaze se svi controlleri. To je ulazna točka za klijentske aplikacije.
## KingICT.Academy.Service
Servisni sloj je ulaz u poslovni svijet. Kroz servisni sloj radi se obrada zahtjeva i kreiraju se odgovori za klijenta.
## KingICT.Academy.Repository
Sloj za dohvat podataka. Dodatan sloj apstrakcije između servisa i podataka.
## KingICT.Academy.Model
Sadrži klase koje predstavljaju domenu oko koje gradimo rješenje te sučelja za pristup podatkovnom sloju.
## KingICT.Academy.Contract
U ovom sloju se nalaze klase i sučelja koja predstavljaju definiciju servisa, što oni mogu raditi, koje parametre primaju i što vraćaju kao rezultat.
## KingICT.Academy.Configuration
Predstavlja jednu vrstu infrastrukture. Tu se nalaze klase koje predstavljaju podatke iz konfiguracijske datoteke.
