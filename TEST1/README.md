# Test 1 (version A)

## ENG

1. Assume that, you've got an algorithm with complexity: T(n) = n * log2(log2(n)). For INPUT_SIZE_1 = 16, PROCESSOR_1 computes the algorithm in 15s. Write a program that counts how long will it take to compute the algorithm with the INPUT_SIZE_2 = 256 and 2x quicker PROCESSOR_2.

2. Write an implementation of mergesort which finds a permutation of indexes of the array of strings (decreasing order). For example: for str1[] = {"Alice", "Jack", "Bob"}, the permutation is: {0, 2, 1};

3. Nana has a family of `k` and has to feed them. The Mc Mins Restaurant offers meals for exactly defined numbers of people. You can't divide the meals and you have to feed all the family members. Price list:
    Amount of people | Price
    -----------------|------
    1|5
    2|8
    3|9
    4|10
    5|7
    6|21

    Find the meals which you can buy with the minimum cost that result in feeding the whole family. Use the greedy approach.

4. Do task 3 but with dynamic programming paradigm.

## PL

1. Rozważmy pewien algorytm  o złożoności czasowej:  T(n) = n log2 (log2 n)

    Czas wykonania tego algorytmu na pewnym komputerze dla danych o rozmiarze n= 16 zabiera 15s. Ile czasu zajmie wykonanie tego algorytmu dla danych o rozmiarze n = 256 na komputerze 2 razy szybszym?
    Uzasadnienie napisać w komentarzu, zaprogramować wzór obliczający czas.

    `double Czas(int n, double sec, int m, int razy)` gdzie `n` rozmiar zadania na pierwszym komputerze, sec czas zadania na pierwszym komputerze, m rozmiar zadania zadania na drugim komputerze, razy  ile razy szybszy drugi komputer, metoda zwraca czas zadania na drugim komputerze. 

2. Napisz implementację algorytmu sortowania przez łączenie, który znajduje taką permutację indeksów, która odpowiada malejącej tablicy stringów. Tablica stringów ma pozostać niezmieniona. 

    `int[] Laczenie(string[] teksty)` gdzie teksty to podana tablica stringów, metoda zwraca tablicę permutacji indeksów

    Przykładowo dla `{"Adam", "Zenek", "Barbara"}` mamy zwrócić `{0, 2, 1}`. Przygotuj kilka zestawów danych testowych, napisz program ilustrujący.

3.  Oszczędna Nana ma zakupić posiłek  k osobowej rodzinie (Nana ma liczną rodzinę). Restauracja Mc Mins wprowadziła zestawy posiłków przeznaczone odpowiednio dla 1, 2 i kolejno więcej osób. Cena posiłku zależy od tego ilu osobowy to jest posiłek. Restauracja wprowadziła zasadę, że grupa osób może zamówić tylko tyle zestawów żeby liczba osób w grupie odpowiada sumarycznej liczbie z zestawów (nie można zamówić więcej bo obowiązuje zasada zero waste oraz dbania o wagę a raczej nadwagę klientów). Każda osoba z rodziny Nany musi zjeść cały posiłek. Nana chciałaby kupić każdemu posiłek wydając jak najmniej. Ceny za kolejne n-osobowe zestawy są podane. Przykładowo za zestaw.
    ```
    1 osobowy   cena  5

    2 osobowy   cena  8

    3 osobowy   cena  9

    4 osobowy   cena  10

    5 osobowy   cena  7

    6 osobowy   cena  21
    ```

    Dla grupy 9 osób najlepszy wynik to 17; grupy  4 i 5 osobowa, dla 12 osób najlepszy wynik to 22; grupy 2, 5 i 5 osobowa. Należy podzielić rodzinę na kilka grup tak, aby każdy zjadł posiłek, a łączna kwota wydana na posiłki była jak najmniejsza. Należy podać kolejne liczby odpowiadające liczebności grup, w przypadku wielu rozwiązań wystarczy podać dowolne rozwiązanie.

    `int[] Grupy(int k, int[] ceny`) gdzie k liczba osób w rodzinie, `int[] ceny {z1, z2,…, zn}` dla kolejnych zestawów  `i (i= 1, 2,.., n)`. Możemy przyjąć, że zi >0. Zwracamy kolejne liczności grup uporządkowane rosnąco względem liczby osób w grupie.

    Wskazówka dla programowania dynamicznego: należy rozpatrywać jak najtaniej można zapewnić posiłek dla rodziny kolejno o liczności 1, 2,…,  k.

4. Zadanie 3, ale zastosować programowanie dynamiczne


