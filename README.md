# WholeSaleManager
Projekt zaliczeniowy wykonany na potrzeby przedmiotu Programowanie w środowisku ASP.NET.

## Krótki opis aplikacji
Nasza aplikacja będzie umożliwiała zarządzanie zamówieniami hurtowo z umożliwieniem zniżki w zależności od zamówionych ilości. 

Docelowym klientem będą firmy budowlane.

Materiały budowlane będzie można zamawiać zarówno jako firma, a także jako indywidualny użytkownik, przy czym w przypadku firmy możemy spodziewać się benefitów.

## Panel administratora - zarys funkcjonalności
Logowanie za pomocą loginu oraz hasła, a także możliwość logowania za pomocą Facebooka lub Gmaila.

Panel zarządzania zawartością, np. kategoriami produktu, a także samym produktem (np. ustalenie progów cenowych w zależnosci od wielkości zamówienia).

Profil admina umożliwa także zarządzanie kontami użytkowników indywidualnych oraz firm. Jeśli firma chce założyć konto, musi skontaktować się z administratorem i tylko on może utworzyć konto dla firmy.

Admin może także utworzyć konto indywidualne a także dokonać jego blokady.

W momencie tworzenia nowego użytkownika, w panelu mamy mozliwość dokonania wyboru roli danego użytkownika. W przypadku, gdy jest to użytkownik firmowy, taki użytkownik musi być przyporządkowany do danej firmy, za pomocą jej indywidualnego unikatowego ID.

### Autoryzowany profil firmowy

W panelu tworzenia firmy jest także możliwość jej autoryzacji jej. Nieautoryzowana firma działa jak zwykły użytkownik. 

Jeśli natomiast firma zostanie zautoryzowana a jej email jest zarejestrowany, może ona wtedy dokonywać zamówień i dokonywać płatności do 30 dni od momentu zamówienia. 

### Zarządzanie zamówieniami

Konto admina ma możliwość zarządzania wszystkimi zamówieniami, z wyszczególnieniem na zamówienia:
- w toku
- oczekujące na potwierdzenie płatności
- zakończone
- odrzucone
- wszystkie

Dla każdego zamówienia mamy jako admin możliwość wyświetlenia szczegółów, gdzie możemy m.in. dodać rodzaj transportu/dostawy itp, a także rozpocząć procesowanie lub dokonać anulacji zamówienia.


## Panel użytkownika - zarys funkcjonalności
