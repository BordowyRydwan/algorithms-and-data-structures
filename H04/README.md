# Homework 4

## ENG

1. Write your own partition algorithm for quicksort.

2. Write your own quicksort algorithm which uses a temporary array (yes, I know it's ineffective)

3. Implement the folllowing partition algorithm:
  * pivot: the middle element 
  * two "pointers" - for first element and last element 
  * execute until the index of second pointer will be lower than the first one: 
    * test the elements until you find the element higher or equal to the left pointer
    * test the elements until you find the element lower or equal to the right pointer
    * if the left element is higher than the right one: 
      * swap the elements 
  * remember the position of left pointer 
  * sort in ascending order.

I'm sorry but task 3 is not understandable even in Polish - that has a serious impact on the translation.

## PL

1. Spróbuj opracować własny podział (dla quicksorta). Przetestuj swoje rozwiązanie.

2. Opracuj sortowanie szybkie z tablicą pomocniczą jak w sortowaniu przez scalanie (mergesort).

3.  Napisz metodę sortowania szybkiego zintegrowaną z algorytmem podziału zgodnie z opisem (tym razem posuwamy się jednocześnie od lewego końca w stronę prawą i od prawego w lewą)
  * wskaż na środkowy element tablicy 
  * zapamiętaj wartość wskazanego elementu jako klucza 
  * wskaż na elementy lewy (pierwszy) i prawy (ostatni) ciągu 
  * wykonuj, aż numer elementu lewego stanie się większy od numeru elementu prawego: 
    * dopóki, zaczynając od wskazanego lewego elementu ciągu, nie znajdziesz elementu lewego większego lub równego kluczowi, testuj kolejne elementy 
    * dopóki, zaczynając od wskazanego prawego elementu ciągu, nie znajdziesz elementu prawego mniejszego lub równego kluczowi, testuj kolejne elementy 
    * jeśli numer lewego elementu jest mniejszy lub równy numerowi prawego elementu, to wykonaj: 
      * zamień te wskazane elementy 
      * wskaż następne elementy lewy i prawy 
  * zapamiętaj numery elementów prawego i lewego, na których zakończono przeszukiwania ciągu zaczynając od początku i od końca. Sortuj elementy od początku do lewego i od prawego do końca.


