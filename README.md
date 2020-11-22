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

Po zarejestrowaniu się w aplikacji użytkownik otrzyma na swój adres e-mail wiadomość umożliwiająca potwierdzenie podanego w procesie rejestracji adresu. W przypadku użytkowników autoryzowanych potwierdzenie adresu e-mail jest wymagane.

### Składanie zamówienia, koszyk oraz podsumowanie

W momencie składania zamówienia dla danego produktu podane są ceny w zależności od ilości w zamówieniu. 

Na etapie koszyka zamówienia użytkownik może edytować zamówienie, m.in. zmieniać ilości oraz usuwać dane pozycje. Jeżeli edycja ilości sprawi, że przekroczy ona zakres dla danej ceny, suma w zamówieniu zostanie automatycznie zaktualizowana.

W następnym etapie wyświetla się podsumowanie zamówienia, gdzie należy także podać dane do wysyłki.

Następnie następuje przekierowanie do bramki płatniczej, a w momencie dokonania płatności zostaje wyświetlony komunikat o pomyślnym bądź też nie sfinalizowaniu zamówienia, użytkownik otrzymuje także wiadomość SMS z potwierdzeniem oraz numerem zamówienia.


### Historia zamówień
Użytkownik może także śledzić zamówienia w panelu historia zamówień. Jest tam możliwość wyświetlenia informacji jakie użytkownik podał w momencie składanie zamówienia, a także podgląd statusu zamówienia.
