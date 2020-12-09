# Homework 10

## ENG

1. Write methods for heap:
    - deleting the highest element
    - inserting new value
    - delete first element of heap

Test your methods for inserting 1, 5, 2, 6, 4, 7, 11, and deleting three elements

2. Write a class for minimum priority queue based on heap (root is the lowest number). The class should contain methods for inserting an element, deleting the lowest one and a property `length`


## PL

1. Z wykładu wiadomo, że aby kopiec mógł być podstawą implementacji kolejki priorytetowej potrzebne są metody wstawiania nowej wartości do kopca i usuwania wartości największej z kopca. Opracuj algorytm wstawiania nowej wartości do kopca, została ona opisana na wykładzie "Dodawanie elementu do kopca binarnego" (UpHeap) . Uwaga: Musisz przygotować większą tablicę i dodatkowo pamiętać ile faktycznie elementów jest w tablicy (reszta to śmieci). Metody z wykładu należy zmienić tak aby miały dodatkowy parametr faktyczną ilość elementów. Należy rozpocząć od umieszczenia nowej wartości na końcu kopca (ostatni liść). Napisz także metodę usuwania pierwszego elementu z kopca (ale kopiec ma być zachowany, wsk. wzoruj się na sortowaniu kopcowym). Narysuj kopiec po kolejnych operacjach wstawiania: 1, 5, 2, 6, 4, 7, 11, a następnie kolejno po usunięciu trzech elementów.

2. Na bazie zadania 1 napisz klasę KolejkaPriorytetowaMin (priorytet ma element o najmniejszej wartości)  przechowującą elementy typu int mającą konstruktor o parametrze int (rozmiar tablicy) oraz następujący interfejs (gdy wartości typu int):
    int Wielkość // właściwość, aktualna liczba elementów w kolejce
    void Wstaw(int wartość)
    int Usun()


